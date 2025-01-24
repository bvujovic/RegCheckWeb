using RegCheckWeb.Classes;
using System.Data;

namespace RegCheckWeb
{
    public partial class FrmMain : Form
    {
        private const string dataSetFileName = "ds.xml";

        public FrmMain()
        {
            InitializeComponent();
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
                ds.WriteXml(dataSetFileName);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message + "\r\nClose the application anyway?"
                    , "Error Info", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                ds.ReadXml(dataSetFileName);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < bs.Count; i++)
            {
                bs.Position = i;
                var page = CurrentWebPage;
                if (page != null)
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
            bs.MoveFirst();
            dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (CurrentWebPage != null)
                Utils.GoToLink(CurrentWebPage.URL);
        }

        private void TsmiPasteTargetStrings_Click(object sender, EventArgs e)
        {
            if (CurrentWebPage != null)
                CurrentWebPage.TargetString = Clipboard.GetText();
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
