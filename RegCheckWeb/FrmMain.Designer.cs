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
            targetFoundDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dgvcTargetFound = new DataGridViewTextBoxColumn();
            dgvcURL = new DataGridViewTextBoxColumn();
            targetStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ctxTargetStrings = new ContextMenuStrip(components);
            tsmiPasteTargetStrings = new ToolStripMenuItem();
            commentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvcEnabled = new DataGridViewCheckBoxColumn();
            bs = new BindingSource(components);
            pnlTop = new Panel();
            btnEnableAll = new Button();
            btnGo = new Button();
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
            dgv.Columns.AddRange(new DataGridViewColumn[] { targetFoundDataGridViewCheckBoxColumn, dgvcTargetFound, dgvcURL, targetStringDataGridViewTextBoxColumn, commentDataGridViewTextBoxColumn, dgvcEnabled });
            dgv.DataSource = bs;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 44);
            dgv.Name = "dgv";
            dgv.Size = new Size(1179, 279);
            dgv.TabIndex = 0;
            dgv.CellDoubleClick += Dgv_CellDoubleClick;
            // 
            // targetFoundDataGridViewCheckBoxColumn
            // 
            targetFoundDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            targetFoundDataGridViewCheckBoxColumn.DataPropertyName = "IsTargetFound";
            targetFoundDataGridViewCheckBoxColumn.HeaderText = "Found";
            targetFoundDataGridViewCheckBoxColumn.Name = "targetFoundDataGridViewCheckBoxColumn";
            targetFoundDataGridViewCheckBoxColumn.ReadOnly = true;
            targetFoundDataGridViewCheckBoxColumn.ThreeState = true;
            targetFoundDataGridViewCheckBoxColumn.Width = 50;
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
            // commentDataGridViewTextBoxColumn
            // 
            commentDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            // 
            // dgvcEnabled
            // 
            dgvcEnabled.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvcEnabled.DataPropertyName = "Enabled";
            dgvcEnabled.HeaderText = "Enabled";
            dgvcEnabled.Name = "dgvcEnabled";
            dgvcEnabled.Resizable = DataGridViewTriState.False;
            dgvcEnabled.Width = 61;
            // 
            // bs
            // 
            bs.DataMember = "WebPages";
            bs.DataSource = ds;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnEnableAll);
            pnlTop.Controls.Add(btnGo);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1179, 44);
            pnlTop.TabIndex = 1;
            // 
            // btnEnableAll
            // 
            btnEnableAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEnableAll.Location = new Point(1083, 8);
            btnEnableAll.Name = "btnEnableAll";
            btnEnableAll.Size = new Size(84, 27);
            btnEnableAll.TabIndex = 1;
            btnEnableAll.Text = "Enable All";
            btnEnableAll.UseVisualStyleBackColor = true;
            btnEnableAll.Click += BtnEnableAll_Click;
            // 
            // btnGo
            // 
            btnGo.Location = new Point(11, 8);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(75, 27);
            btnGo.TabIndex = 0;
            btnGo.Text = "&Go";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += BtnGo_Click;
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
        private Button btnEnableAll;
        private DataGridViewCheckBoxColumn targetFoundDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dgvcTargetFound;
        private DataGridViewTextBoxColumn dgvcURL;
        private DataGridViewTextBoxColumn targetStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn dgvcEnabled;
    }
}
