namespace AzureCacheExplorer
{
    partial class Connections
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwCredentials = new System.Windows.Forms.ListView();
            this.colFriendlyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndpoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFriendyName = new System.Windows.Forms.TextBox();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.txtAccessKey = new System.Windows.Forms.TextBox();
            this.lblFriendlyName = new System.Windows.Forms.Label();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.lblAccessKey = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwCredentials
            // 
            this.lvwCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCredentials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFriendlyName,
            this.colEndpoint});
            this.lvwCredentials.FullRowSelect = true;
            this.lvwCredentials.GridLines = true;
            this.lvwCredentials.LabelEdit = true;
            this.lvwCredentials.Location = new System.Drawing.Point(12, 91);
            this.lvwCredentials.MultiSelect = false;
            this.lvwCredentials.Name = "lvwCredentials";
            this.lvwCredentials.ShowGroups = false;
            this.lvwCredentials.Size = new System.Drawing.Size(485, 129);
            this.lvwCredentials.TabIndex = 0;
            this.lvwCredentials.UseCompatibleStateImageBehavior = false;
            this.lvwCredentials.View = System.Windows.Forms.View.Details;
            this.lvwCredentials.SelectedIndexChanged += new System.EventHandler(this.lvwCredentials_SelectedIndexChanged);
            this.lvwCredentials.Resize += new System.EventHandler(this.lvwCredentials_Resize);
            // 
            // colFriendlyName
            // 
            this.colFriendlyName.Text = "Friendly Name";
            this.colFriendlyName.Width = 200;
            // 
            // colEndpoint
            // 
            this.colEndpoint.Text = "Endpoint";
            this.colEndpoint.Width = 280;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(421, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(340, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFriendyName
            // 
            this.txtFriendyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFriendyName.Location = new System.Drawing.Point(93, 13);
            this.txtFriendyName.Name = "txtFriendyName";
            this.txtFriendyName.Size = new System.Drawing.Size(404, 20);
            this.txtFriendyName.TabIndex = 3;
            this.txtFriendyName.WordWrap = false;
            this.txtFriendyName.TextChanged += new System.EventHandler(this.txtFriendyName_TextChanged);
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndpoint.Location = new System.Drawing.Point(93, 39);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(404, 20);
            this.txtEndpoint.TabIndex = 4;
            this.txtEndpoint.WordWrap = false;
            this.txtEndpoint.TextChanged += new System.EventHandler(this.txtEndpoint_TextChanged);
            // 
            // txtAccessKey
            // 
            this.txtAccessKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccessKey.Location = new System.Drawing.Point(93, 65);
            this.txtAccessKey.Name = "txtAccessKey";
            this.txtAccessKey.Size = new System.Drawing.Size(404, 20);
            this.txtAccessKey.TabIndex = 5;
            this.txtAccessKey.WordWrap = false;
            this.txtAccessKey.TextChanged += new System.EventHandler(this.txtAccessKey_TextChanged);
            // 
            // lblFriendlyName
            // 
            this.lblFriendlyName.AutoSize = true;
            this.lblFriendlyName.Location = new System.Drawing.Point(13, 16);
            this.lblFriendlyName.Name = "lblFriendlyName";
            this.lblFriendlyName.Size = new System.Drawing.Size(74, 13);
            this.lblFriendlyName.TabIndex = 6;
            this.lblFriendlyName.Text = "Friendly Name";
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(13, 42);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(49, 13);
            this.lblEndpoint.TabIndex = 7;
            this.lblEndpoint.Text = "Endpoint";
            // 
            // lblAccessKey
            // 
            this.lblAccessKey.AutoSize = true;
            this.lblAccessKey.Location = new System.Drawing.Point(12, 68);
            this.lblAccessKey.Name = "lblAccessKey";
            this.lblAccessKey.Size = new System.Drawing.Size(63, 13);
            this.lblAccessKey.TabIndex = 8;
            this.lblAccessKey.Text = "Access Key";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(12, 226);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(93, 226);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Connections
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(509, 261);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAccessKey);
            this.Controls.Add(this.lblEndpoint);
            this.Controls.Add(this.lblFriendlyName);
            this.Controls.Add(this.txtAccessKey);
            this.Controls.Add(this.txtEndpoint);
            this.Controls.Add(this.txtFriendyName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvwCredentials);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(525, 216);
            this.Name = "Connections";
            this.Text = "Stored Connections";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Connections_FormClosing);
            this.Load += new System.EventHandler(this.Connections_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCredentials;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFriendyName;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.TextBox txtAccessKey;
        private System.Windows.Forms.Label lblFriendlyName;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.Label lblAccessKey;
        private System.Windows.Forms.ColumnHeader colFriendlyName;
        private System.Windows.Forms.ColumnHeader colEndpoint;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
    }
}