using AzureCacheExplorer.Credentials;
using Microsoft.ApplicationServer.Caching;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureCacheExplorer
{
    public partial class frmExplorer : Form
    {
        private JsonSerializerSettings _settings;

        private CredentialsHelper _credentialsHelper;
        private CacheInteraction _cacheInteraction;
        private string _selectedKey;
        private string _selectedVersion;

        public delegate void BackgroundWorkStarted(string TaskName);
        public delegate void BackgroundWorkStopped();
        public delegate void SetProgressMaximum(int maximum);
        public delegate void SetProgress(int progress);

        public frmExplorer()
        {
            InitializeComponent();
            lvwKeys.DoubleBuffered(true);
            txtValue.DoubleBuffered(true);
        }

        private void frmExplorer_Load(object sender, EventArgs e)
        {
            _settings = new JsonSerializerSettings();
            _settings.Formatting = Formatting.Indented;
            _settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string cacheName = txtCacheName.Text.Trim();
            if(_credentialsHelper.Credentials.CacheName != cacheName)
            {
                _credentialsHelper.Credentials.CacheName = cacheName;
                _credentialsHelper.Save();
            }

            ConnectToCache();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the entire cache? This is pretty dangerous.", "Clear entire cache?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                _cacheInteraction.Clear();
                tsslActionStatus.Text = "Cleared cache";
                RefreshCacheKeys();
            }
        }

        private async void btnClearVersion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Are you sure you want to clear cache version {0}?", _selectedVersion), "Clear cache version?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                tsslActionStatus.Text = string.Format("Clearing version {0}", _selectedVersion);
                this.UseWaitCursor = true;
                this.Refresh();
                int keysRemoved = 0;

                await Task.Run(() =>
                {
                    keysRemoved = _cacheInteraction.ClearVersion(_selectedVersion);
                });

                tsslActionStatus.Text = string.Format("Cleared version {0}, removed {1} keys", _selectedVersion, keysRemoved);
                this.Refresh();
                RefreshCacheKeys();
                this.UseWaitCursor = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _cacheInteraction.Remove(_selectedVersion, _selectedKey);
            ClearCacheItemDetails();
            tsslActionStatus.Text = string.Format("Removed key {0}", _selectedKey);
            RefreshCacheKeys();
        }

        private async void ConnectToCache()
        {
            lvwKeys.Items.Clear();
            tsslKeyCount.Text = "";
            tsslActionStatus.Text = "";
            tsslConnection.Text = "Connecting...";
            ClearCacheItemDetails();
            btnClear.Enabled = false;
            btnClearVersion.Enabled = false;
            btnManageCredentials.Enabled = false;
            btnRemove.Enabled = false;
            cboCredentials.Enabled = false;
            btnGetAllKeys.Enabled = false;
            cboVersions.Enabled = false;
            this.Refresh();

            int selectedCredentialIndex = cboCredentials.SelectedIndex;
            string cacheName = txtCacheName.Text;    
            try
            {
                await Task.Run(() =>
                {
                    _cacheInteraction = new CacheInteraction();
                    _cacheInteraction.CacheInteractionStartProgress += _cacheInteraction_CacheInteractionStartProgress;
                    _cacheInteraction.CacheInteractionProgress += _cacheInteraction_CacheInteractionProgress;
                    _cacheInteraction.CacheInteractionStartBusy += _cacheInteraction_CacheInteractionStartBusy;
                    _cacheInteraction.CacheInteractionEndBusy += _cacheInteraction_CacheInteractionEndBusy;
                    _cacheInteraction.Connect(selectedCredentialIndex, _credentialsHelper, cacheName);
                });
            }
            catch (Exception ex)
            {
                _cacheInteraction_CacheInteractionEndBusy(this, new CacheInteractionEndBusyEventArgs());
                tsslConnection.Text = string.Format("Could not connect to {0} (Exception: {1})", _credentialsHelper.GetCredential(selectedCredentialIndex).FriendlyName, ex.Message);
                return;
            }

            tsslConnection.Text = string.Format("Connected to {0}", _credentialsHelper.GetCredential(selectedCredentialIndex).FriendlyName);
            btnGetAllKeys.Text = "Refresh";
            RefreshCacheKeys();
            cboCredentials.Enabled = true;
            btnGetAllKeys.Enabled = true;

            btnManageCredentials.Enabled = true;
            this.Refresh();
        }

        private void _cacheInteraction_CacheInteractionEndBusy(object sender, CacheInteractionEndBusyEventArgs e)
        {
            if(this.InvokeRequired)
            {
                Invoke(new BackgroundWorkStopped(EndWork));
            }
            else
            {
                EndWork();
            }
        }

        private void EndWork()
        {
            tspbProgress.Visible = false;
            tsslActionStatus.Text = "";
        }
        

        private void _cacheInteraction_CacheInteractionStartBusy(object sender, CacheInteractionStartBusyEventArgs e)
        {
            if(this.InvokeRequired)
            {
                Invoke(new BackgroundWorkStarted(StartWork), new object[] {e.TaskName});
            }
            else
            {
                StartWork(e.TaskName);
            }
        }

        private void StartWork(string taskName)
        {
            if (!tspbProgress.Visible)
            {
                tspbProgress.Visible = true;
            }

            tspbProgress.Style = ProgressBarStyle.Marquee;
            tsslActionStatus.Text = taskName;
            ssMain.Refresh();
        }

        private void _cacheInteraction_CacheInteractionProgress(object sender, CacheInteractionProgressEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new SetProgress(Progress), new object[] { e.Progress });
            }
            else
            {
                Progress(e.Progress);
            }
        }

        private void Progress(int progressAmount)
        {
            if (progressAmount > tspbProgress.Maximum)
            {
                tspbProgress.Value = tspbProgress.Maximum;
                return;
            }

            if (progressAmount < tspbProgress.Minimum)
            {
                tspbProgress.Value = tspbProgress.Minimum;
                return;
            }

            tspbProgress.Value = progressAmount;
        }


        private void _cacheInteraction_CacheInteractionStartProgress(object sender, CacheInteractionStartProgressEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new SetProgressMaximum(SetMaximumProgress), new object[] { e.MaxProgress });
            }
            else
            {
                SetMaximumProgress(e.MaxProgress);
            }
        }

        private void SetMaximumProgress(int progressMaximum)
        {
            tspbProgress.Visible = true;
            tspbProgress.Style = ProgressBarStyle.Blocks;
            tspbProgress.Value = 0;
            tspbProgress.Maximum = progressMaximum;
        }

        private void SelectItem(int selectedItemIndex)
        {
            if(selectedItemIndex < 0 || selectedItemIndex >= _cacheInteraction.FilteredKeyCount)
            {
                ClearCacheItemDetails();
                return;
            }

            _selectedKey = _cacheInteraction.GetItem(selectedItemIndex);
            
            try
            {
                DataCacheItem response = _cacheInteraction.GetCacheItem(_selectedVersion, _selectedKey);
                
                try
                {
                    object responseValue = response.Value;
                    lblItemTypeValue.Text = responseValue.GetType().GetCSharpRepresentation(true);
                    txtValue.Text = JsonConvert.SerializeObject(response.Value, Formatting.Indented, _settings);
                }
                catch (SerializationException)
                {
                    txtValue.Text = "Caught SerializationException, Serialized data is:" + Environment.NewLine + GetSerializedValue(response);
                }
                catch (Exception)
                {
                    try 
                    {
                        txtValue.Text = "Caught Exception, serialized data is: " + Environment.NewLine + GetSerializedValue(response);
                    }
                    catch  
                    {
                        txtValue.Text = "Cannot display cache item";
                    }    
                }
                   
                lblCacheNameValue.Text = response.CacheName;
                lblExtensionTimeoutValue.Text = string.Format("{0:N0} seconds", response.ExtensionTimeout.TotalSeconds);
                lblRegionNameValue.Text = response.RegionName;
                lblSizeValue.Text = string.Format("{0:N0} bytes", response.Size);
                lblTimeoutValue.Text = string.Format("{0:N0} seconds", response.Timeout.TotalSeconds);
                    
                btnRemove.Enabled = true;
            }
            catch
            {
                txtValue.Text = string.Format("Cache item {0} for version {1} has expired or been removed.", _selectedKey, _selectedVersion);
                lblCacheNameValue.Text = "Expired";
                lblExtensionTimeoutValue.Text = "Expired";
                lblRegionNameValue.Text = "Expired";
                lblSizeValue.Text = "Expired";
                lblTimeoutValue.Text = "Expired";
            }
            tsslActionStatus.Text = "";
            lblKeyNameValue.Text = _selectedKey;
        }

        private void SetKeyCount(int count, int filteredCount = -1)
        {
            int newListSize;

            switch (count)
            {
                case 0:
                    tsslKeyCount.Text = "No cache keys";
                    newListSize = 0;
                    break;

                case 1:
                    if (filteredCount == -1 || filteredCount == 1)
                    {
                        tsslKeyCount.Text = "1 cache key";
                        newListSize = 1;
                    }
                    else
                    {
                        tsslKeyCount.Text = "0 of 1 cache keys";
                        newListSize = 0;
                    }
                    break;
                    
                default:
                    if (filteredCount == -1 || filteredCount == count)
                    {
                        tsslKeyCount.Text = string.Format("{0} cache keys", count);
                        newListSize = count;
                    }
                    else
                    {
                        tsslKeyCount.Text = string.Format("{0} of {1} cache keys", filteredCount, count);
                        newListSize = filteredCount;
                    }
                    
                    break;
            }

            ClearCacheItemDetails();

            if(lvwKeys.VirtualListSize == newListSize)
            {
                return;
            }

            if (newListSize == 0)
            {
                lvwKeys.VirtualListSize = 0;
                lvwKeys.SelectedIndices.Clear();
                lvwKeys.VirtualMode = false;
            }
            else
            {
                try
                {
                    lvwKeys.EnsureVisible(0);
                }
                catch
                {
                    //do nothing, just trying to avoid stupidity
                }
                

                if(lvwKeys.VirtualMode == false)
                {
                    lvwKeys.VirtualMode = true;
                }
                try
                {
                    lvwKeys.VirtualListSize = newListSize;
                }
                catch //nothing to catch, just trying to avoid stupidness with listview
                {
                    
                }
            }
        }

        private void ClearCacheItemDetails()
        {
            txtValue.Text = "";
            lblCacheNameValue.Text = "";
            lblExtensionTimeoutValue.Text = "";
            lblRegionNameValue.Text = "";
            lblSizeValue.Text = "";
            lblTimeoutValue.Text = "";
            lblKeyNameValue.Text = "";
            lblItemTypeValue.Text = "";
            btnRemove.Enabled = false;
            _selectedKey = null;
        }

        private async void RefreshCacheKeys()
        {
            SetKeyCount(0);
            tsslKeyCount.Text = "";
            ClearCacheItemDetails();
            btnClearVersion.Enabled = false;
            btnRemove.Enabled = false;
            txtSearch.Enabled = false;
            cboVersions.Enabled = false;

            this.Refresh();
            string[] versions = null;

            await Task.Run(() =>  
            {
                 versions = _cacheInteraction.GetVersions().ToArray();
            });

            cboVersions.Items.Clear();
            cboVersions.Items.AddRange(versions);

            if(cboVersions.Items.Count == 0)
            {
                tsslKeyCount.Text = "No cache keys";
                return;
            }
            
            cboVersions.SelectedIndex = 0;
            FilterCacheKeyList();
            txtSearch.Enabled = true;
            btnClear.Enabled = true;

            if (versions.Length == 1 && versions[0] == CacheInteraction.UNVERSIONED_PREFIX)
            {
                return;
            }
            btnClearVersion.Enabled = true;
            if(versions.Length > 1)
            {
                cboVersions.Enabled = true;
            }
        }

        private void lvwKeys_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if(_cacheInteraction == null || e.ItemIndex >= _cacheInteraction.FilteredKeyCount || e.ItemIndex < 0)
            {
                e.Item = new ListViewItem("");
                return;
            }

            string itemKey = _cacheInteraction.GetItem(e.ItemIndex);
            if(itemKey.Length > 259)
            {
                itemKey = itemKey.Substring(0, 258) + "…";
            }

            ListViewItem item = new ListViewItem(itemKey); //max length is 259 characters;

            e.Item = item;
        }

        private void cboVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedVersion = cboVersions.SelectedItem.ToString();
            FilterCacheKeyList();
        }

        private void lvwKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwKeys.SelectedIndices.Count > 0)
            {
                SelectItem(lvwKeys.SelectedIndices[0]);
            }
            else
            {
                ClearCacheItemDetails();
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterCacheKeyList();
        }

        private void FilterCacheKeyList()
        {
            _cacheInteraction.FilterCacheKeyList(_selectedVersion, txtSearch.Text);
            SetKeyCount(_cacheInteraction.TotalKeyCount(_selectedVersion), _cacheInteraction.FilteredKeyCount);
            CheckColumnSize();
        }

        private void CheckColumnSize()
        { 
            if(lvwKeys.Columns[0].Width != lvwKeys.ClientSize.Width)
            {
                lvwKeys.Columns[0].Width = -2;
            }
            
        }

        private void lvwKeys_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(lvwKeys.Sorting == SortOrder.Ascending)
            {
                _cacheInteraction.SortKeys(false);
                lvwKeys.Sorting = SortOrder.Descending;
            }
            else
            {
                _cacheInteraction.SortKeys(true);
                lvwKeys.Sorting = SortOrder.Ascending;
            }

            lvwKeys.Refresh();
        }

        private void lvwKeys_Layout(object sender, LayoutEventArgs e)
        {
            CheckColumnSize();
        }

        private void btnManageCredentials_Click(object sender, EventArgs e)
        {
            Connections connection = new Connections(_credentialsHelper.Credentials, new JsonCacheCredentialsPersistence());
            connection.ShowDialog();

            _credentialsHelper.Load();
            LoadCredentialsList();
        }

        private void LoadCredentialsList()
        {
            cboCredentials.Items.Clear();

            cboCredentials.Items.AddRange(_credentialsHelper.Credentials.Credentials.Select(x => x.FriendlyName).ToArray());

            int selectedIndex = _credentialsHelper.Credentials.SelectedCredentialIndex;

            if (selectedIndex < 0 && cboCredentials.Items.Count > 0)
            {
                cboCredentials.SelectedIndex = 0;
                return;
            }

            if (selectedIndex >= cboCredentials.Items.Count)
            {
                cboCredentials.SelectedIndex = cboCredentials.Items.Count - 1;
                return;
            }

            cboCredentials.SelectedIndex = selectedIndex;
        }

        private void cboCredentials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCredentials.SelectedIndex > -1)
            {
                _credentialsHelper.Credentials.SelectedCredentialIndex = cboCredentials.SelectedIndex;
                ClearCacheItemDetails();
                SetKeyCount(0);
                cboVersions.Items.Clear();
                cboVersions.Enabled = false;
                tsslKeyCount.Text = "";
                btnGetAllKeys.Text = "Connect";
                tsslActionStatus.Text = "Disconnected";
                _cacheInteraction = null;
            }
        }

        private void frmExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _credentialsHelper.Save();
        }

        private void frmExplorer_Shown(object sender, EventArgs e)
        {
            _credentialsHelper = new CredentialsHelper();
            LoadCredentialsList();
            txtCacheName.Text = _credentialsHelper.Credentials.CacheName;
        }

        private string GetSerializedValue(DataCacheItem dataCacheItem)
        {
            PropertyInfo getSerializedValueMethod = dataCacheItem.GetType().GetProperty("SerializedValue", BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder(1024);
            object[] getKeysParams = new object[] {  };

            byte[][] serializedValueAs2DByteArray = getSerializedValueMethod.GetValue(dataCacheItem) as byte[][];

            foreach(byte[] row in serializedValueAs2DByteArray)
            {
                foreach(byte b in row)
                {
                    if(b > 0)
                    {
                        char c = (char)b;
                        if (char.IsControl(c))
                        {
                            sb.Append(" ");
                        }
                        else
                        {
                            sb.Append(c);
                        }
                    }
                    
                }
            }

            return sb.ToString();
        }
    }
}
