namespace FileSorter
{
    partial class Main
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pgGeneral = new System.Windows.Forms.TabPage();
            this.gridFiles = new System.Windows.Forms.DataGridView();
            this.clmnCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnExt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSourcePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDestPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pgFolders = new System.Windows.Forms.TabPage();
            this.gridDestinations = new System.Windows.Forms.DataGridView();
            this.clmnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBtnRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDestFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBtnPath = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.pgGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiles)).BeginInit();
            this.pgFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDestinations)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(463, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(436, 6);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(100, 23);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(0, 6);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(95, 23);
            this.btnSelectFolder.TabIndex = 3;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pgGeneral);
            this.tabControl1.Controls.Add(this.pgFolders);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 317);
            this.tabControl1.TabIndex = 5;
            // 
            // pgGeneral
            // 
            this.pgGeneral.Controls.Add(this.gridFiles);
            this.pgGeneral.Controls.Add(this.btnSelectFolder);
            this.pgGeneral.Controls.Add(this.btnMove);
            this.pgGeneral.Location = new System.Drawing.Point(4, 22);
            this.pgGeneral.Name = "pgGeneral";
            this.pgGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.pgGeneral.Size = new System.Drawing.Size(542, 291);
            this.pgGeneral.TabIndex = 0;
            this.pgGeneral.Text = "General";
            this.pgGeneral.UseVisualStyleBackColor = true;
            // 
            // gridFiles
            // 
            this.gridFiles.AllowUserToAddRows = false;
            this.gridFiles.AllowUserToDeleteRows = false;
            this.gridFiles.AllowUserToOrderColumns = true;
            this.gridFiles.AllowUserToResizeRows = false;
            this.gridFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnCheckBox,
            this.clmnFileName,
            this.clmnExt,
            this.clmnSourcePath,
            this.clmnDestPath});
            this.gridFiles.Location = new System.Drawing.Point(3, 35);
            this.gridFiles.Name = "gridFiles";
            this.gridFiles.RowHeadersVisible = false;
            this.gridFiles.RowTemplate.Height = 18;
            this.gridFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridFiles.Size = new System.Drawing.Size(536, 253);
            this.gridFiles.TabIndex = 4;
            // 
            // clmnCheckBox
            // 
            this.clmnCheckBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmnCheckBox.FalseValue = "false";
            this.clmnCheckBox.FillWeight = 6.367628F;
            this.clmnCheckBox.HeaderText = " ";
            this.clmnCheckBox.MinimumWidth = 23;
            this.clmnCheckBox.Name = "clmnCheckBox";
            this.clmnCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnCheckBox.TrueValue = "true";
            this.clmnCheckBox.Width = 26;
            // 
            // clmnFileName
            // 
            this.clmnFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmnFileName.HeaderText = "File Name";
            this.clmnFileName.Name = "clmnFileName";
            this.clmnFileName.ReadOnly = true;
            this.clmnFileName.Width = 79;
            // 
            // clmnExt
            // 
            this.clmnExt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmnExt.HeaderText = "Extension";
            this.clmnExt.Name = "clmnExt";
            this.clmnExt.ReadOnly = true;
            this.clmnExt.Width = 78;
            // 
            // clmnSourcePath
            // 
            this.clmnSourcePath.FillWeight = 97.72928F;
            this.clmnSourcePath.HeaderText = "_FullPath";
            this.clmnSourcePath.Name = "clmnSourcePath";
            this.clmnSourcePath.ReadOnly = true;
            // 
            // clmnDestPath
            // 
            this.clmnDestPath.FillWeight = 206.5415F;
            this.clmnDestPath.HeaderText = "_DestDir";
            this.clmnDestPath.Name = "clmnDestPath";
            // 
            // pgFolders
            // 
            this.pgFolders.Controls.Add(this.gridDestinations);
            this.pgFolders.Location = new System.Drawing.Point(4, 22);
            this.pgFolders.Name = "pgFolders";
            this.pgFolders.Padding = new System.Windows.Forms.Padding(3);
            this.pgFolders.Size = new System.Drawing.Size(542, 291);
            this.pgFolders.TabIndex = 1;
            this.pgFolders.Text = "Folders";
            this.pgFolders.UseVisualStyleBackColor = true;
            // 
            // gridDestinations
            // 
            this.gridDestinations.AllowUserToAddRows = false;
            this.gridDestinations.AllowUserToDeleteRows = false;
            this.gridDestinations.AllowUserToResizeRows = false;
            this.gridDestinations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDestinations.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridDestinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDestinations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnID,
            this.clmnBtnRemove,
            this.clmnExtension,
            this.clmnDestFolder,
            this.clmnBtnPath});
            this.gridDestinations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDestinations.Location = new System.Drawing.Point(3, 3);
            this.gridDestinations.MultiSelect = false;
            this.gridDestinations.Name = "gridDestinations";
            this.gridDestinations.RowHeadersVisible = false;
            this.gridDestinations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDestinations.Size = new System.Drawing.Size(536, 285);
            this.gridDestinations.TabIndex = 0;
            this.gridDestinations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDestinations_CellClick);
            // 
            // clmnID
            // 
            this.clmnID.HeaderText = "ID";
            this.clmnID.Name = "clmnID";
            this.clmnID.ReadOnly = true;
            this.clmnID.Visible = false;
            // 
            // clmnBtnRemove
            // 
            this.clmnBtnRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmnBtnRemove.FillWeight = 13.50844F;
            this.clmnBtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clmnBtnRemove.HeaderText = " ";
            this.clmnBtnRemove.Name = "clmnBtnRemove";
            this.clmnBtnRemove.ReadOnly = true;
            this.clmnBtnRemove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnBtnRemove.Width = 23;
            // 
            // clmnExtension
            // 
            this.clmnExtension.FillWeight = 35.45966F;
            this.clmnExtension.HeaderText = "Extension";
            this.clmnExtension.Name = "clmnExtension";
            // 
            // clmnDestFolder
            // 
            this.clmnDestFolder.FillWeight = 253.0778F;
            this.clmnDestFolder.HeaderText = "Destination Folder";
            this.clmnDestFolder.Name = "clmnDestFolder";
            this.clmnDestFolder.ReadOnly = true;
            // 
            // clmnBtnPath
            // 
            this.clmnBtnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmnBtnPath.FillWeight = 13.50844F;
            this.clmnBtnPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clmnBtnPath.HeaderText = " ";
            this.clmnBtnPath.Name = "clmnBtnPath";
            this.clmnBtnPath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnBtnPath.Width = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 47);
            this.panel1.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 364);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "SrutchRemoova";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.pgGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFiles)).EndInit();
            this.pgFolders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDestinations)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pgGeneral;
        private System.Windows.Forms.TabPage pgFolders;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridDestinations;
        private System.Windows.Forms.DataGridView gridFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDestFolder;
        private System.Windows.Forms.DataGridViewButtonColumn clmnBtnPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnExt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnSourcePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDestPath;
        private System.Windows.Forms.DataGridViewButtonColumn clmnBtnRemove;
    }
}

