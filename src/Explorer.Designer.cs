namespace AzureCacheExplorer
{
    partial class frmExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExplorer));
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnGetAllKeys = new System.Windows.Forms.Button();
            this.scMainView = new System.Windows.Forms.SplitContainer();
            this.btnClearVersion = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cboVersions = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lvwKeys = new System.Windows.Forms.ListView();
            this.chKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbCacheItem = new System.Windows.Forms.GroupBox();
            this.lblKeyNameValue = new System.Windows.Forms.Label();
            this.lblKeyNameKey = new System.Windows.Forms.Label();
            this.lblExtensionTimeoutValue = new System.Windows.Forms.Label();
            this.lblTimeoutValue = new System.Windows.Forms.Label();
            this.lblSizeValue = new System.Windows.Forms.Label();
            this.lblRegionNameValue = new System.Windows.Forms.Label();
            this.lblCacheNameValue = new System.Windows.Forms.Label();
            this.lblExtensionTimeoutKey = new System.Windows.Forms.Label();
            this.lblTimeoutKey = new System.Windows.Forms.Label();
            this.lblSizeKey = new System.Windows.Forms.Label();
            this.lblRegionNameKey = new System.Windows.Forms.Label();
            this.lblCacheNameKey = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslKeyCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslActionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCacheCredentials = new System.Windows.Forms.Label();
            this.btnManageCredentials = new System.Windows.Forms.Button();
            this.cboCredentials = new System.Windows.Forms.ComboBox();
            this.lblCacheName = new System.Windows.Forms.Label();
            this.txtCacheName = new System.Windows.Forms.TextBox();
            this.lblItemTypeKey = new System.Windows.Forms.Label();
            this.lblItemTypeValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scMainView)).BeginInit();
            this.scMainView.Panel1.SuspendLayout();
            this.scMainView.Panel2.SuspendLayout();
            this.scMainView.SuspendLayout();
            this.gbCacheItem.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(277, 353);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(86, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnGetAllKeys
            // 
            this.btnGetAllKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetAllKeys.Location = new System.Drawing.Point(900, 10);
            this.btnGetAllKeys.Name = "btnGetAllKeys";
            this.btnGetAllKeys.Size = new System.Drawing.Size(75, 23);
            this.btnGetAllKeys.TabIndex = 4;
            this.btnGetAllKeys.Text = "Connect";
            this.btnGetAllKeys.UseVisualStyleBackColor = true;
            this.btnGetAllKeys.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // scMainView
            // 
            this.scMainView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMainView.Location = new System.Drawing.Point(15, 39);
            this.scMainView.Name = "scMainView";
            // 
            // scMainView.Panel1
            // 
            this.scMainView.Panel1.Controls.Add(this.btnClearVersion);
            this.scMainView.Panel1.Controls.Add(this.btnClear);
            this.scMainView.Panel1.Controls.Add(this.lblVersion);
            this.scMainView.Panel1.Controls.Add(this.cboVersions);
            this.scMainView.Panel1.Controls.Add(this.txtSearch);
            this.scMainView.Panel1.Controls.Add(this.lblSearch);
            this.scMainView.Panel1.Controls.Add(this.lvwKeys);
            this.scMainView.Panel1MinSize = 100;
            // 
            // scMainView.Panel2
            // 
            this.scMainView.Panel2.Controls.Add(this.gbCacheItem);
            this.scMainView.Panel2MinSize = 100;
            this.scMainView.Size = new System.Drawing.Size(960, 388);
            this.scMainView.SplitterDistance = 579;
            this.scMainView.TabIndex = 12;
            // 
            // btnClearVersion
            // 
            this.btnClearVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearVersion.Enabled = false;
            this.btnClearVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearVersion.Location = new System.Drawing.Point(462, 3);
            this.btnClearVersion.Name = "btnClearVersion";
            this.btnClearVersion.Size = new System.Drawing.Size(110, 23);
            this.btnClearVersion.TabIndex = 36;
            this.btnClearVersion.Text = "Clear cache version";
            this.btnClearVersion.UseVisualStyleBackColor = true;
            this.btnClearVersion.Click += new System.EventHandler(this.btnClearVersion_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Enabled = false;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClear.Location = new System.Drawing.Point(343, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 23);
            this.btnClear.TabIndex = 35;
            this.btnClear.Text = "Clear entire cache";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(9, 6);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 18;
            this.lblVersion.Text = "Version";
            // 
            // cboVersions
            // 
            this.cboVersions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVersions.Enabled = false;
            this.cboVersions.Location = new System.Drawing.Point(100, 3);
            this.cboVersions.Name = "cboVersions";
            this.cboVersions.Size = new System.Drawing.Size(237, 21);
            this.cboVersions.Sorted = true;
            this.cboVersions.TabIndex = 17;
            this.cboVersions.SelectedIndexChanged += new System.EventHandler(this.cboVersions_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(100, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(472, 20);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(9, 33);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(85, 13);
            this.lblSearch.TabIndex = 14;
            this.lblSearch.Text = "Keys containing:";
            // 
            // lvwKeys
            // 
            this.lvwKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chKey});
            this.lvwKeys.FullRowSelect = true;
            this.lvwKeys.Location = new System.Drawing.Point(9, 56);
            this.lvwKeys.MultiSelect = false;
            this.lvwKeys.Name = "lvwKeys";
            this.lvwKeys.ShowGroups = false;
            this.lvwKeys.Size = new System.Drawing.Size(563, 329);
            this.lvwKeys.TabIndex = 13;
            this.lvwKeys.UseCompatibleStateImageBehavior = false;
            this.lvwKeys.View = System.Windows.Forms.View.Details;
            this.lvwKeys.VirtualMode = true;
            this.lvwKeys.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwKeys_ColumnClick);
            this.lvwKeys.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwKeys_RetrieveVirtualItem);
            this.lvwKeys.SelectedIndexChanged += new System.EventHandler(this.lvwKeys_SelectedIndexChanged);
            this.lvwKeys.Layout += new System.Windows.Forms.LayoutEventHandler(this.lvwKeys_Layout);
            // 
            // chKey
            // 
            this.chKey.Text = "Cache Key";
            this.chKey.Width = 559;
            // 
            // gbCacheItem
            // 
            this.gbCacheItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCacheItem.Controls.Add(this.lblItemTypeValue);
            this.gbCacheItem.Controls.Add(this.lblItemTypeKey);
            this.gbCacheItem.Controls.Add(this.lblKeyNameValue);
            this.gbCacheItem.Controls.Add(this.lblKeyNameKey);
            this.gbCacheItem.Controls.Add(this.lblExtensionTimeoutValue);
            this.gbCacheItem.Controls.Add(this.lblTimeoutValue);
            this.gbCacheItem.Controls.Add(this.lblSizeValue);
            this.gbCacheItem.Controls.Add(this.lblRegionNameValue);
            this.gbCacheItem.Controls.Add(this.btnRemove);
            this.gbCacheItem.Controls.Add(this.lblCacheNameValue);
            this.gbCacheItem.Controls.Add(this.lblExtensionTimeoutKey);
            this.gbCacheItem.Controls.Add(this.lblTimeoutKey);
            this.gbCacheItem.Controls.Add(this.lblSizeKey);
            this.gbCacheItem.Controls.Add(this.lblRegionNameKey);
            this.gbCacheItem.Controls.Add(this.lblCacheNameKey);
            this.gbCacheItem.Controls.Add(this.txtValue);
            this.gbCacheItem.Controls.Add(this.lblValue);
            this.gbCacheItem.Location = new System.Drawing.Point(3, 3);
            this.gbCacheItem.Name = "gbCacheItem";
            this.gbCacheItem.Size = new System.Drawing.Size(369, 382);
            this.gbCacheItem.TabIndex = 17;
            this.gbCacheItem.TabStop = false;
            // 
            // lblKeyNameValue
            // 
            this.lblKeyNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNameValue.AutoEllipsis = true;
            this.lblKeyNameValue.Location = new System.Drawing.Point(149, 16);
            this.lblKeyNameValue.Name = "lblKeyNameValue";
            this.lblKeyNameValue.Size = new System.Drawing.Size(214, 13);
            this.lblKeyNameValue.TabIndex = 30;
            // 
            // lblKeyNameKey
            // 
            this.lblKeyNameKey.AutoSize = true;
            this.lblKeyNameKey.Location = new System.Drawing.Point(7, 16);
            this.lblKeyNameKey.Name = "lblKeyNameKey";
            this.lblKeyNameKey.Size = new System.Drawing.Size(25, 13);
            this.lblKeyNameKey.TabIndex = 29;
            this.lblKeyNameKey.Text = "Key";
            // 
            // lblExtensionTimeoutValue
            // 
            this.lblExtensionTimeoutValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExtensionTimeoutValue.AutoEllipsis = true;
            this.lblExtensionTimeoutValue.Location = new System.Drawing.Point(149, 116);
            this.lblExtensionTimeoutValue.Name = "lblExtensionTimeoutValue";
            this.lblExtensionTimeoutValue.Size = new System.Drawing.Size(214, 13);
            this.lblExtensionTimeoutValue.TabIndex = 28;
            // 
            // lblTimeoutValue
            // 
            this.lblTimeoutValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeoutValue.AutoEllipsis = true;
            this.lblTimeoutValue.Location = new System.Drawing.Point(149, 96);
            this.lblTimeoutValue.Name = "lblTimeoutValue";
            this.lblTimeoutValue.Size = new System.Drawing.Size(214, 13);
            this.lblTimeoutValue.TabIndex = 27;
            // 
            // lblSizeValue
            // 
            this.lblSizeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSizeValue.AutoEllipsis = true;
            this.lblSizeValue.Location = new System.Drawing.Point(149, 76);
            this.lblSizeValue.Name = "lblSizeValue";
            this.lblSizeValue.Size = new System.Drawing.Size(214, 13);
            this.lblSizeValue.TabIndex = 26;
            // 
            // lblRegionNameValue
            // 
            this.lblRegionNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegionNameValue.AutoEllipsis = true;
            this.lblRegionNameValue.Location = new System.Drawing.Point(149, 56);
            this.lblRegionNameValue.Name = "lblRegionNameValue";
            this.lblRegionNameValue.Size = new System.Drawing.Size(214, 13);
            this.lblRegionNameValue.TabIndex = 25;
            // 
            // lblCacheNameValue
            // 
            this.lblCacheNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCacheNameValue.AutoEllipsis = true;
            this.lblCacheNameValue.Location = new System.Drawing.Point(149, 36);
            this.lblCacheNameValue.Name = "lblCacheNameValue";
            this.lblCacheNameValue.Size = new System.Drawing.Size(214, 13);
            this.lblCacheNameValue.TabIndex = 24;
            // 
            // lblExtensionTimeoutKey
            // 
            this.lblExtensionTimeoutKey.AutoSize = true;
            this.lblExtensionTimeoutKey.Location = new System.Drawing.Point(7, 116);
            this.lblExtensionTimeoutKey.Name = "lblExtensionTimeoutKey";
            this.lblExtensionTimeoutKey.Size = new System.Drawing.Size(94, 13);
            this.lblExtensionTimeoutKey.TabIndex = 23;
            this.lblExtensionTimeoutKey.Text = "Extension Timeout";
            // 
            // lblTimeoutKey
            // 
            this.lblTimeoutKey.AutoSize = true;
            this.lblTimeoutKey.Location = new System.Drawing.Point(7, 96);
            this.lblTimeoutKey.Name = "lblTimeoutKey";
            this.lblTimeoutKey.Size = new System.Drawing.Size(45, 13);
            this.lblTimeoutKey.TabIndex = 22;
            this.lblTimeoutKey.Text = "Timeout";
            // 
            // lblSizeKey
            // 
            this.lblSizeKey.AutoSize = true;
            this.lblSizeKey.Location = new System.Drawing.Point(7, 76);
            this.lblSizeKey.Name = "lblSizeKey";
            this.lblSizeKey.Size = new System.Drawing.Size(27, 13);
            this.lblSizeKey.TabIndex = 21;
            this.lblSizeKey.Text = "Size";
            // 
            // lblRegionNameKey
            // 
            this.lblRegionNameKey.AutoSize = true;
            this.lblRegionNameKey.Location = new System.Drawing.Point(7, 56);
            this.lblRegionNameKey.Name = "lblRegionNameKey";
            this.lblRegionNameKey.Size = new System.Drawing.Size(72, 13);
            this.lblRegionNameKey.TabIndex = 20;
            this.lblRegionNameKey.Text = "Region Name";
            // 
            // lblCacheNameKey
            // 
            this.lblCacheNameKey.AutoSize = true;
            this.lblCacheNameKey.Location = new System.Drawing.Point(7, 36);
            this.lblCacheNameKey.Name = "lblCacheNameKey";
            this.lblCacheNameKey.Size = new System.Drawing.Size(69, 13);
            this.lblCacheNameKey.TabIndex = 19;
            this.lblCacheNameKey.Text = "Cache Name";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(10, 172);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtValue.Size = new System.Drawing.Size(353, 175);
            this.txtValue.TabIndex = 18;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(7, 156);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 17;
            this.lblValue.Text = "Value";
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbProgress,
            this.tsslKeyCount,
            this.tsslActionStatus,
            this.tsslConnection});
            this.ssMain.Location = new System.Drawing.Point(0, 435);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(987, 22);
            this.ssMain.TabIndex = 13;
            this.ssMain.Text = "statusStrip1";
            // 
            // tspbProgress
            // 
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(100, 16);
            this.tspbProgress.Value = 50;
            this.tspbProgress.Visible = false;
            // 
            // tsslKeyCount
            // 
            this.tsslKeyCount.Name = "tsslKeyCount";
            this.tsslKeyCount.Size = new System.Drawing.Size(0, 17);
            this.tsslKeyCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslActionStatus
            // 
            this.tsslActionStatus.Name = "tsslActionStatus";
            this.tsslActionStatus.Size = new System.Drawing.Size(886, 17);
            this.tsslActionStatus.Spring = true;
            this.tsslActionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslConnection
            // 
            this.tsslConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslConnection.Name = "tsslConnection";
            this.tsslConnection.Size = new System.Drawing.Size(86, 17);
            this.tsslConnection.Text = "Not connected";
            this.tsslConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCacheCredentials
            // 
            this.lblCacheCredentials.AutoSize = true;
            this.lblCacheCredentials.Location = new System.Drawing.Point(12, 15);
            this.lblCacheCredentials.Name = "lblCacheCredentials";
            this.lblCacheCredentials.Size = new System.Drawing.Size(64, 13);
            this.lblCacheCredentials.TabIndex = 17;
            this.lblCacheCredentials.Text = "Connection:";
            // 
            // btnManageCredentials
            // 
            this.btnManageCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageCredentials.Location = new System.Drawing.Point(527, 10);
            this.btnManageCredentials.Name = "btnManageCredentials";
            this.btnManageCredentials.Size = new System.Drawing.Size(75, 23);
            this.btnManageCredentials.TabIndex = 18;
            this.btnManageCredentials.Text = "Manage";
            this.btnManageCredentials.UseVisualStyleBackColor = true;
            this.btnManageCredentials.Click += new System.EventHandler(this.btnManageCredentials_Click);
            // 
            // cboCredentials
            // 
            this.cboCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCredentials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCredentials.Location = new System.Drawing.Point(82, 12);
            this.cboCredentials.Name = "cboCredentials";
            this.cboCredentials.Size = new System.Drawing.Size(439, 21);
            this.cboCredentials.TabIndex = 19;
            this.cboCredentials.SelectedIndexChanged += new System.EventHandler(this.cboCredentials_SelectedIndexChanged);
            // 
            // lblCacheName
            // 
            this.lblCacheName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCacheName.AutoSize = true;
            this.lblCacheName.Location = new System.Drawing.Point(608, 15);
            this.lblCacheName.Name = "lblCacheName";
            this.lblCacheName.Size = new System.Drawing.Size(70, 13);
            this.lblCacheName.TabIndex = 20;
            this.lblCacheName.Text = "Cache name:";
            // 
            // txtCacheName
            // 
            this.txtCacheName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCacheName.Location = new System.Drawing.Point(684, 12);
            this.txtCacheName.Name = "txtCacheName";
            this.txtCacheName.Size = new System.Drawing.Size(210, 20);
            this.txtCacheName.TabIndex = 21;
            // 
            // lblItemTypeKey
            // 
            this.lblItemTypeKey.AutoSize = true;
            this.lblItemTypeKey.Location = new System.Drawing.Point(7, 136);
            this.lblItemTypeKey.Name = "lblItemTypeKey";
            this.lblItemTypeKey.Size = new System.Drawing.Size(31, 13);
            this.lblItemTypeKey.TabIndex = 31;
            this.lblItemTypeKey.Text = "Type";
            // 
            // lblItemTypeValue
            // 
            this.lblItemTypeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemTypeValue.AutoEllipsis = true;
            this.lblItemTypeValue.Location = new System.Drawing.Point(149, 136);
            this.lblItemTypeValue.Name = "lblItemTypeValue";
            this.lblItemTypeValue.Size = new System.Drawing.Size(214, 13);
            this.lblItemTypeValue.TabIndex = 32;
            // 
            // frmExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 457);
            this.Controls.Add(this.lblCacheCredentials);
            this.Controls.Add(this.txtCacheName);
            this.Controls.Add(this.lblCacheName);
            this.Controls.Add(this.cboCredentials);
            this.Controls.Add(this.btnManageCredentials);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.scMainView);
            this.Controls.Add(this.btnGetAllKeys);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExplorer";
            this.Text = "Azure cache explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExplorer_FormClosing);
            this.Load += new System.EventHandler(this.frmExplorer_Load);
            this.Shown += new System.EventHandler(this.frmExplorer_Shown);
            this.scMainView.Panel1.ResumeLayout(false);
            this.scMainView.Panel1.PerformLayout();
            this.scMainView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMainView)).EndInit();
            this.scMainView.ResumeLayout(false);
            this.gbCacheItem.ResumeLayout(false);
            this.gbCacheItem.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnGetAllKeys;
        private System.Windows.Forms.SplitContainer scMainView;
        private System.Windows.Forms.ListView lvwKeys;
        private System.Windows.Forms.ColumnHeader chKey;
        private System.Windows.Forms.GroupBox gbCacheItem;
        private System.Windows.Forms.Label lblExtensionTimeoutValue;
        private System.Windows.Forms.Label lblTimeoutValue;
        private System.Windows.Forms.Label lblSizeValue;
        private System.Windows.Forms.Label lblRegionNameValue;
        private System.Windows.Forms.Label lblCacheNameValue;
        private System.Windows.Forms.Label lblExtensionTimeoutKey;
        private System.Windows.Forms.Label lblTimeoutKey;
        private System.Windows.Forms.Label lblSizeKey;
        private System.Windows.Forms.Label lblRegionNameKey;
        private System.Windows.Forms.Label lblCacheNameKey;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tsslKeyCount;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnection;
        private System.Windows.Forms.Label lblKeyNameValue;
        private System.Windows.Forms.Label lblKeyNameKey;
        private System.Windows.Forms.Label lblCacheCredentials;
        private System.Windows.Forms.ToolStripStatusLabel tsslActionStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ComboBox cboVersions;
        private System.Windows.Forms.Button btnClearVersion;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnManageCredentials;
        private System.Windows.Forms.ComboBox cboCredentials;
        private System.Windows.Forms.Label lblCacheName;
        private System.Windows.Forms.TextBox txtCacheName;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
        private System.Windows.Forms.Label lblItemTypeValue;
        private System.Windows.Forms.Label lblItemTypeKey;
    }
}

