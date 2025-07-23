namespace RegCheckWeb
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            ds = new Ds();
            dgv = new DataGridView();
            dgvcTargetFound = new DataGridViewTextBoxColumn();
            dgvcURL = new DataGridViewTextBoxColumn();
            targetStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ctxTargetStrings = new ContextMenuStrip(components);
            tsmiPasteTargetStrings = new ToolStripMenuItem();
            dgvcComment = new DataGridViewTextBoxColumn();
            targetFoundDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dgvcImage = new DataGridViewButtonColumn();
            bs = new BindingSource(components);
            pnlTop = new Panel();
            btnMaxiReplaceHash = new Button();
            btnAppFolderBrowse = new Button();
            btnPageOrderUp = new Button();
            btnGo = new Button();
            timImage = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)ds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            ctxTargetStrings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bs).BeginInit();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // ds
            // 
            ds.DataSetName = "Ds";
            ds.Namespace = "http://tempuri.org/Ds.xsd";
            ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgv
            // 
            dgv.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dgv.AutoGenerateColumns = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { dgvcTargetFound, dgvcURL, targetStringDataGridViewTextBoxColumn, dgvcComment, targetFoundDataGridViewCheckBoxColumn, dgvcImage });
            dgv.DataSource = bs;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 44);
            dgv.Name = "dgv";
            dgv.Size = new Size(1179, 279);
            dgv.TabIndex = 0;
            dgv.CellClick += Dgv_CellClick;
            dgv.CellDoubleClick += Dgv_CellDoubleClick;
            dgv.CellMouseEnter += Dgv_CellMouseEnter;
            // 
            // dgvcTargetFound
            // 
            dgvcTargetFound.DataPropertyName = "TargetFound";
            dgvcTargetFound.HeaderText = "Target Found";
            dgvcTargetFound.Name = "dgvcTargetFound";
            dgvcTargetFound.ReadOnly = true;
            dgvcTargetFound.Visible = false;
            dgvcTargetFound.Width = 200;
            // 
            // dgvcURL
            // 
            dgvcURL.DataPropertyName = "URL";
            dgvcURL.HeaderText = "URL";
            dgvcURL.Name = "dgvcURL";
            dgvcURL.Width = 400;
            // 
            // targetStringDataGridViewTextBoxColumn
            // 
            targetStringDataGridViewTextBoxColumn.ContextMenuStrip = ctxTargetStrings;
            targetStringDataGridViewTextBoxColumn.DataPropertyName = "TargetString";
            targetStringDataGridViewTextBoxColumn.HeaderText = "Targets";
            targetStringDataGridViewTextBoxColumn.Name = "targetStringDataGridViewTextBoxColumn";
            targetStringDataGridViewTextBoxColumn.Width = 200;
            // 
            // ctxTargetStrings
            // 
            ctxTargetStrings.Items.AddRange(new ToolStripItem[] { tsmiPasteTargetStrings });
            ctxTargetStrings.Name = "contextMenuStrip1";
            ctxTargetStrings.Size = new Size(103, 26);
            // 
            // tsmiPasteTargetStrings
            // 
            tsmiPasteTargetStrings.Name = "tsmiPasteTargetStrings";
            tsmiPasteTargetStrings.Size = new Size(102, 22);
            tsmiPasteTargetStrings.Text = "Paste";
            tsmiPasteTargetStrings.Click += TsmiPasteTargetStrings_Click;
            // 
            // dgvcComment
            // 
            dgvcComment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvcComment.DataPropertyName = "Comment";
            dgvcComment.HeaderText = "Comment";
            dgvcComment.Name = "dgvcComment";
            // 
            // targetFoundDataGridViewCheckBoxColumn
            // 
            targetFoundDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            targetFoundDataGridViewCheckBoxColumn.DataPropertyName = "IsTargetFound";
            targetFoundDataGridViewCheckBoxColumn.HeaderText = "Found";
            targetFoundDataGridViewCheckBoxColumn.Name = "targetFoundDataGridViewCheckBoxColumn";
            targetFoundDataGridViewCheckBoxColumn.ReadOnly = true;
            targetFoundDataGridViewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            targetFoundDataGridViewCheckBoxColumn.ThreeState = true;
            targetFoundDataGridViewCheckBoxColumn.Width = 69;
            // 
            // dgvcImage
            // 
            dgvcImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvcImage.DataPropertyName = "ImageStr";
            dgvcImage.HeaderText = "Image";
            dgvcImage.Name = "dgvcImage";
            dgvcImage.ReadOnly = true;
            dgvcImage.Width = 50;
            // 
            // bs
            // 
            bs.DataMember = "WebPages";
            bs.DataSource = ds;
            bs.Sort = "Order, Id";
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnMaxiReplaceHash);
            pnlTop.Controls.Add(btnAppFolderBrowse);
            pnlTop.Controls.Add(btnPageOrderUp);
            pnlTop.Controls.Add(btnGo);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1179, 44);
            pnlTop.TabIndex = 1;
            // 
            // btnMaxiReplaceHash
            // 
            btnMaxiReplaceHash.FlatStyle = FlatStyle.Popup;
            btnMaxiReplaceHash.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMaxiReplaceHash.Location = new Point(378, 8);
            btnMaxiReplaceHash.Name = "btnMaxiReplaceHash";
            btnMaxiReplaceHash.Size = new Size(143, 28);
            btnMaxiReplaceHash.TabIndex = 4;
            btnMaxiReplaceHash.Text = "&Maxi: Replace hash";
            btnMaxiReplaceHash.UseVisualStyleBackColor = true;
            btnMaxiReplaceHash.Click += BtnMaxiReplaceHash_Click;
            // 
            // btnAppFolderBrowse
            // 
            btnAppFolderBrowse.FlatStyle = FlatStyle.Popup;
            btnAppFolderBrowse.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAppFolderBrowse.Location = new Point(297, 8);
            btnAppFolderBrowse.Name = "btnAppFolderBrowse";
            btnAppFolderBrowse.Size = new Size(75, 28);
            btnAppFolderBrowse.TabIndex = 3;
            btnAppFolderBrowse.Text = "&Folder...";
            btnAppFolderBrowse.UseVisualStyleBackColor = true;
            btnAppFolderBrowse.Click += BtnAppFolderBrowse_Click;
            // 
            // btnPageOrderUp
            // 
            btnPageOrderUp.FlatStyle = FlatStyle.Popup;
            btnPageOrderUp.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPageOrderUp.Location = new Point(154, 8);
            btnPageOrderUp.Margin = new Padding(0);
            btnPageOrderUp.Name = "btnPageOrderUp";
            btnPageOrderUp.Size = new Size(85, 28);
            btnPageOrderUp.TabIndex = 2;
            btnPageOrderUp.Text = "Move 🔼";
            btnPageOrderUp.UseVisualStyleBackColor = true;
            btnPageOrderUp.Click += BtnPageOrderUp_Click;
            // 
            // btnGo
            // 
            btnGo.BackColor = Color.LightGreen;
            btnGo.FlatStyle = FlatStyle.Popup;
            btnGo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGo.Location = new Point(11, 8);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(75, 28);
            btnGo.TabIndex = 0;
            btnGo.Text = "&Go";
            btnGo.UseVisualStyleBackColor = false;
            btnGo.Click += BtnGo_Click;
            // 
            // timImage
            // 
            timImage.Interval = 500;
            timImage.Tick += TimImage_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 323);
            Controls.Add(dgv);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegCheckWeb";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)ds).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ctxTargetStrings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bs).EndInit();
            pnlTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Ds ds;
        private DataGridView dgv;
        private BindingSource bs;
        private Panel pnlTop;
        private Button btnGo;
        private ContextMenuStrip ctxTargetStrings;
        private ToolStripMenuItem tsmiPasteTargetStrings;
        private Button btnPageOrderUp;
        private Button btnAppFolderBrowse;
        private DataGridViewTextBoxColumn dgvcTargetFound;
        private DataGridViewTextBoxColumn dgvcURL;
        private DataGridViewTextBoxColumn targetStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dgvcComment;
        private DataGridViewCheckBoxColumn targetFoundDataGridViewCheckBoxColumn;
        private DataGridViewButtonColumn dgvcImage;
        private System.Windows.Forms.Timer timImage;
        private Button btnMaxiReplaceHash;
    }
}
