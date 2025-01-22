using RegCheckWeb.Classes;
using System.Data;
using System.Diagnostics.Eventing.Reader;

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
                    page.SetTargetFoundNull();
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

                //var chkElite = new Check("https://www.pansport.rs/proteini/elite-100-whey-protein?sku=1902"
                //    , "commerce-price-savings-formatter-prices-count-3");
                //if (await chkElite.FindTarget())
                //    MessageBox.Show(chkElite.ToString());

                //// https://www.pansport.rs/proteini/100-whey-protein-professional?sku=1129
                //// https://www.pansport.rs/proteini/100-whey-protein-professional?sku=1129
                //// https://www.pansport.rs/proteini/100-whey-protein-professional?sku=634

                ////var chkBuild = new Check("https://www.pansport.rs/proteini/ultra-premium-whey-build?sku=1163"
                ////    , "commerce-price-savings-formatter-prices-count-3");
                ////MessageBox.Show((await chkBuild.FindTarget()).ToString());

                //var chkPanSearch = new Check("https://www.pansport.rs/search?pretraga=Maxler"
                //    , "commerce-price-savings-formatter-list odd");
                //if (await chkPanSearch.FindTarget())
                //    MessageBox.Show(chkPanSearch.ToString());

                //var chkEdb1 = new Check("https://elektrodistribucija.rs/planirana-iskljucenja-beograd/Dan_1_Iskljucenja.htm"
                //    , "КРАЉИЦЕ КАТАРИНЕ");
                //if (await chkEdb1.FindTarget())
                //    MessageBox.Show(chkEdb1.ToString());

                //var chkEdb11 = new Check("https://elektrodistribucija.rs/planirana-iskljucenja-beograd/Dan_1_Iskljucenja.htm"
                //    , "СЕЛИНСКА");
                //if (await chkEdb11.FindTarget())
                //    MessageBox.Show(chkEdb11.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bs.Count; i++)
            {
                bs.Position = i;
                var drv = bs.Current as DataRowView;
                if (drv?.Row is Ds.WebPagesRow row)
                {
                    var chk = new Check(row.URL, row.TargetString);
                    row.TargetFound = await chk.FindTarget();
                }
            }
        }
    }
}
