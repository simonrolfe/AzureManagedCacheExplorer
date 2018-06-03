using AzureCacheExplorer.Credentials;
using System;
using System.Windows.Forms;

namespace AzureCacheExplorer
{
    public partial class Connections : Form
    {
        private CacheCredentials _credentials;
        private CacheCredentials _storedCredentials;
        private ICredentialsPersistence _credentialsPersistence;

        public Connections(CacheCredentials credentials, ICredentialsPersistence credentialsPersistence)
        {
            _storedCredentials = credentials;
            _credentials = credentials.Copy(); //copy the object so we don't affect the main copy
            _credentialsPersistence = credentialsPersistence;
            InitializeComponent();
        }

        private void Connections_Load(object sender, EventArgs e)
        {
            lvwCredentials.Items.Clear();
            
            foreach(CacheCredential cred in _credentials.Credentials)
            {
                lvwCredentials.Items.Add(new ListViewItem(new string[]{cred.FriendlyName, cred.EndpointName}));
            }

            txtFriendyName.SetWatermark("Display name for this connection");
            txtEndpoint.SetWatermark(".cache.windows.net will be added automatically");
            txtAccessKey.SetWatermark("Can be primary or secondary access key");
        }

        private void lvwCredentials_SelectedIndexChanged(object sender, EventArgs e)
        {
            CacheCredential credential = GetSelectedCredential();
            if(credential == null)
            {
                ClearSelectedCredential(); 
            }
            else
            {
                SetSelectedCredential(credential);
            }
            CheckRemoveButton();
        }

        private bool CheckItemDirty()
        {
            CacheCredential credential = GetSelectedCredential();
            if (credential == null)
            {
                return (!string.IsNullOrWhiteSpace(txtAccessKey.Text) || !string.IsNullOrWhiteSpace(txtEndpoint.Text) || !string.IsNullOrWhiteSpace(txtFriendyName.Text));
            }
            if (txtAccessKey.Text != credential.AccessKey)
            {
                return true;
            }
            if (txtEndpoint.Text != credential.EndpointName)
            {
                return true;
            }
            if (txtFriendyName.Text != credential.FriendlyName)
            {
                return true;
            }
            return false;
        }

        private bool CredentialSaveNeeded()
        {
            if(_credentials.Credentials.Count != _storedCredentials.Credentials.Count)
            {
                return true;
            }

            for (int i = 0; i < _credentials.Credentials.Count; i++ )
            {
                if(_credentials.Credentials[i] != _storedCredentials.Credentials[i])
                {
                    return true;
                }
            }

                return false;
        }

        private CacheCredential GetSelectedCredential()
        {
            if (lvwCredentials.SelectedIndices.Count > 0)
            {
                return _credentials.Credentials[lvwCredentials.SelectedIndices[0]];
            }
            else
            {
                return null;
            }
        }

        private void SetSelectedCredential(CacheCredential credential)
        {
            txtAccessKey.Text = credential.AccessKey;
            txtEndpoint.Text = credential.EndpointName;
            txtFriendyName.Text = credential.FriendlyName;
            btnDelete.Enabled = true;
            btnAdd.Text = "Edit";
        }

        private void ClearSelectedCredential()
        {
            txtAccessKey.Text = "";
            txtEndpoint.Text = "";
            txtFriendyName.Text = "";
            btnDelete.Enabled = false;
            btnAdd.Text = "Add";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFriendyName.Text))
            {
                MessageBox.Show("Please provide a friendly name.", "Cannot add stored credential", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEndpoint.Text))
            {
                MessageBox.Show("Please provide an endpoint.", "Cannot add stored credential", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAccessKey.Text))
            {
                MessageBox.Show("Please provide an access key.", "Cannot add stored credential", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            bool addMode = false;
            CacheCredential cred = GetSelectedCredential();
            if(cred == null)
            {
                addMode = true;
                cred = new CacheCredential();
            }
            
            cred.AccessKey = txtAccessKey.Text.Trim();
            cred.EndpointName = txtEndpoint.Text.Trim();
            cred.FriendlyName = txtFriendyName.Text.Trim();
            if (addMode)
            {
                _credentials.Credentials.Add(cred);

                ListViewItem lvi = new ListViewItem(cred.FriendlyName);
                lvi.SubItems.Add(cred.EndpointName);

                lvwCredentials.Items.Add(lvi);

                lvwCredentials.Items[lvwCredentials.Items.Count - 1].Selected = true;
            }
            else
            {
                lvwCredentials.SelectedItems[0].SubItems[0].Text = cred.FriendlyName;
                lvwCredentials.SelectedItems[0].SubItems[1].Text = cred.EndpointName;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CacheCredential cred = GetSelectedCredential();
            if(MessageBox.Show(string.Format("Are you sure you want to delete the stored credentials '{0}'?", cred.FriendlyName), "Delete stored credential?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _credentials.Credentials.Remove(cred);
                lvwCredentials.Items.RemoveAt(lvwCredentials.SelectedIndices[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _storedCredentials = _credentials; //save the working credentials over the top of the stored ones
            _credentialsPersistence.Save(_credentials);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFriendyName_TextChanged(object sender, EventArgs e)
        {
            CheckSaveAndAddButton();
        }

        private void CheckSaveAndAddButton()
        {
            bool itemDirty = CheckItemDirty();
            btnAdd.Enabled = itemDirty;
            btnSave.Enabled = itemDirty || CredentialSaveNeeded();
        }

        private void CheckRemoveButton()
        {
            btnDelete.Enabled = lvwCredentials.SelectedIndices.Count > 0;
        }

        private void txtEndpoint_TextChanged(object sender, EventArgs e)
        {
            CheckSaveAndAddButton();
        }

        private void txtAccessKey_TextChanged(object sender, EventArgs e)
        {
            CheckSaveAndAddButton();
        }

        private void Connections_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                if (CredentialSaveNeeded())
                {
                    if (MessageBox.Show("You have unsaved credentials. Are you sure you wish to cancel?", "Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;

                    }
                }
            }
        }

        private void lvwCredentials_Resize(object sender, EventArgs e)
        {
            colEndpoint.Width = -2;
        }
    }
}
