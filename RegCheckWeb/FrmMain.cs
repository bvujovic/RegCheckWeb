using RegCheckWeb.Classes;
using System.Data;
using System.Diagnostics;

namespace RegCheckWeb
{
    public partial class FrmMain : Form
    {
        private const string dataSetFileName = "ds.xml";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Utils.Ds = ds;
                ds.ReadXml(dataSetFileName);

                Width = Utils.ReadIntSetting(nameof(Width), Width);
                Height = Utils.ReadIntSetting(nameof(Height), Height);
                Left = Utils.ReadIntSetting(nameof(Left), Left);
                Top = Utils.ReadIntSetting(nameof(Top), Top);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (var page in ds.WebPages)
                {
                    page.SetIsTargetFoundNull();
                    page.SetTargetFoundNull();
                }
                Utils.SaveSetting(nameof(Width), Width.ToString());
                Utils.SaveSetting(nameof(Height), Height.ToString());
                Utils.SaveSetting(nameof(Left), Left.ToString());
                Utils.SaveSetting(nameof(Top), Top.ToString());

                ds.WriteXml(dataSetFileName);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message + "\r\nClose the application anyway?"
                    , "Error Info", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            //var cc = new Check("https://www.maxi.rs/api/v1/?operationName=GetProductSearch&variables=%7B%22lang%22%3A%22sr%22%2C%22searchQuery%22%3A%22nescafe%3Arelevance%22%2C%22sort%22%3A%22relevance%22%2C%22pageNumber%22%3A0%2C%22pageSize%22%3A20%2C%22filterFlag%22%3Atrue%2C%22plainChildCategories%22%3Atrue%2C%22useSpellingSuggestion%22%3Atrue%7D&extensions=%7B%22persistedQuery%22%3A%7B%22version%22%3A1%2C%22sha256Hash%22%3A%226909f822520b85fd9cb787fb1dd1491824795f27cc6746d6585c6830d96646b7%22%7D%7D"
            //    , "asdf");
            //await cc.FindTarget();
            //return;

            if (dgv.SelectedRows.Count == 0)
                dgv.SelectAll();
            var selected = dgv.SelectedRows;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in selected)
            {
                if (row.IsNewRow)
                    continue;
                bs.Position = row.Index;
                var page = CurrentWebPage;
                if (page != null && !page.IsTargetStringNull() && page.Enabled)
                {
                    var chk = new Check(page.URL, page.TargetString);
                    var found = await chk.FindTarget();
                    page.IsTargetFound = found.Any();
                    if (page.TargetString.Contains(Environment.NewLine) && page.IsTargetFound)
                    {
                        page.TargetFound = string.Join(", ", found);
                        dgvcTargetFound.Visible = true;
                    }
                }
            }
            bs.Position = selected[0].Index;
            dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != dgvcURL.Index)
                return;
            if (CurrentWebPage != null && CurrentWebPage.RowState != DataRowState.Detached)
                Utils.GoToLink(CurrentWebPage.URL);
        }

        private void TsmiPasteTargetStrings_Click(object sender, EventArgs e)
        {
            if (CurrentWebPage != null)
                CurrentWebPage.TargetString = Clipboard.GetText();
        }

        private bool enableAll = true;
        private void BtnEnableAll_Click(object sender, EventArgs e)
        {
            foreach (var page in ds.WebPages)
                page.Enabled = enableAll;
            enableAll = !enableAll;
            btnEnableAll.Text = enableAll ? "Enable All" : "Disable All";
        }

        public Ds.WebPagesRow? CurrentWebPage
        {
            get
            {
                var drv = bs.Current as DataRowView;
                return drv?.Row as Ds.WebPagesRow;
            }
        }
    }
}
