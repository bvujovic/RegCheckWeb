using RegCheckWeb.Classes;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static RegCheckWeb.Ds;

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
                ds.WebPages.TableNewRow += WebPages_TableNewRow;
                ds.ReadXml(dataSetFileName);
                EnumerateImageFiles();

                //foreach (var page in ds.WebPages)
                //{
                //    if (page.IsOrderNull())
                //        page.Order = -page.Id;
                //    Debug.WriteLine(page.Order);
                //}
                var screen = Screen.PrimaryScreen!.WorkingArea;
                Width = Utils.ReadIntSetting(nameof(Width), Width, it => it > 100 && it <= screen.Width);
                Height = Utils.ReadIntSetting(nameof(Height), Height, it => it > 100 && it <= screen.Height);
                Left = Utils.ReadIntSetting(nameof(Left), Left, it => it >= 0 && it < screen.Width);
                Top = Utils.ReadIntSetting(nameof(Top), Top, it => it >= 0 && it <= screen.Height);

                var lastBackup = Utils.ReadDateTimeSetting("lastBackup", DateTime.MinValue);
                if ((DateTime.Now - lastBackup).TotalDays >= 7)
                {
                    ds.WriteXml($"backup/{DateTime.Now.ToString(Utils.DatumVremeFormatFileMin)}.xml");
                    Utils.SaveSetting("lastBackup", DateTime.Now.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void WebPages_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (e.Row is WebPagesRow page)
                page.Order = ds.WebPages.Count == 0 ? 1 : ds.WebPages.Max(it => it.Order) + 1;
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
                if (WindowState == FormWindowState.Normal)
                {
                    Utils.SaveSetting(nameof(Width), Width.ToString());
                    Utils.SaveSetting(nameof(Height), Height.ToString());
                    Utils.SaveSetting(nameof(Left), Left.ToString());
                    Utils.SaveSetting(nameof(Top), Top.ToString());
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

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            //var cc = new Check("https://www.maxi.rs/api/v1/?operationName=GetProductSearch&variables=%7B%22lang%22%3A%22sr%22%2C%22searchQuery%22%3A%22nescafe%3Arelevance%22%2C%22sort%22%3A%22relevance%22%2C%22pageNumber%22%3A0%2C%22pageSize%22%3A20%2C%22filterFlag%22%3Atrue%2C%22plainChildCategories%22%3Atrue%2C%22useSpellingSuggestion%22%3Atrue%7D&extensions=%7B%22persistedQuery%22%3A%7B%22version%22%3A1%2C%22sha256Hash%22%3A%226909f822520b85fd9cb787fb1dd1491824795f27cc6746d6585c6830d96646b7%22%7D%7D"
            //    , "asdf");
            //await cc.FindTarget();
            //return;
            dgvcTargetFound.Visible = false;
            if (dgv.SelectedRows.Count == 0)
                dgv.SelectAll();
            var selected = dgv.SelectedRows.Cast<DataGridViewRow>().Reverse();
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in selected)
            {
                if (row.IsNewRow)
                    continue;
                bs.Position = row.Index;
                var page = CurrentWebPage;
                if (page != null && !page.IsTargetStringNull())
                    try
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
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("PERSISTED_QUERY_NOT_FOUND"))
                        {
                            page.IsTargetFound = false;
                            page.TargetFound = "PERSISTED_QUERY_NOT_FOUND";
                            dgvcTargetFound.Visible = true;
                        }
                        else
                            MessageBox.Show(ex.Message);
                    }
            }
            bs.Position = selected.First().Index;
            dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || CurrentWebPage == null || CurrentWebPage.RowState == DataRowState.Detached)
                return;
            var page = CurrentWebPage;
            if (e.ColumnIndex == dgvcURL.Index)
                Utils.GoToLink(page.URL);
            if (e.ColumnIndex == dgvcComment.Index && !page.IsCommentNull() && Utils.IsWebLink(page.Comment))
                Utils.GoToLink(page.Comment);
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || CurrentWebPage == null || CurrentWebPage.RowState == DataRowState.Detached)
                return;
            if (e.ColumnIndex == dgvcImage.Index)
            {
                var page = CurrentWebPage;
                var filePath = ImageFilePath(page.Id);
                if (File.Exists(filePath))
                    CloseImage(page.Id);
                else
                {
                    if (Clipboard.ContainsImage() && page != null)
                        try
                        {
                            var image = Clipboard.GetImage();
                            image?.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            page.ImageStr = "...";
                        }
                        catch (Exception ex) { MessageBox.Show($"Error saving image: {ex.Message}"); }
                    else
                        MessageBox.Show("No image found in the clipboard.");
                }
            }
        }

        private static string ImageFilePath(int pageId)
            => $"images/img_{-pageId:000}.jpeg";

        private static FrmImage? frmImage = null;

        private static bool IsFrmImageAlive
            //=> !(frmImage == null || frmImage.Disposing || frmImage.IsDisposed);
            => frmImage != null && !frmImage.Disposing && !frmImage.IsDisposed;

        public static void CloseImage(int pageId)
        {
            if (IsFrmImageAlive && frmImage!.Slika == ImageFilePath(pageId))
                frmImage.Close();
        }

        public static void ShowImage(int pageId)
        {
            try
            {
                if (frmImage == null || frmImage.Disposing || frmImage.IsDisposed)
                    frmImage = new FrmImage();
                frmImage.Slika = ImageFilePath(pageId);
                frmImage.Show();
                frmImage.Activate();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void EnumerateImageFiles()
        {
            var folderPath = "images";
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"Folder '{folderPath}' does not exist.", nameof(EnumerateImageFiles));
                return;
            }
            var files = Directory.GetFiles(folderPath, "img_*.jpeg");
            var regex = new Regex(@"img_(\d+)\.jpeg");
            var ids = new List<int>();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var match = regex.Match(fileName);
                if (match.Success && int.TryParse(match.Groups[1].Value, out var id))
                    ids.Add(id);
            }
            foreach (var page in ds.WebPages)
                page.ImageStr = ids.Contains(-page.Id) ? "..." : "";
        }

        private void TsmiPasteTargetStrings_Click(object sender, EventArgs e)
        {
            if (CurrentWebPage != null)
                CurrentWebPage.TargetString = Clipboard.GetText();
        }

        private void BtnPageOrderUp_Click(object sender, EventArgs e)
        {
            if (CurrentWebPage == null)
                return;
            var ord = CurrentWebPage.Order;
            var ords = ds.WebPages.Select(it => it.Order).Where(it => it < ord);
            if (!ords.Any())
                return;
            var swapPage = ds.WebPages.First(it => it.Order == ords.Max());
            (swapPage.Order, CurrentWebPage.Order) = (CurrentWebPage.Order, swapPage.Order);
        }

        private void BtnAppFolderBrowse_Click(object sender, EventArgs e)
        {
            Utils.OpenFile(Directory.GetCurrentDirectory());
        }

        private void Dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != dgvcImage.Index)
                return;
            imageRowIndex = e.RowIndex;
            timImage.Start();
        }

        private int imageRowIndex = -1;

        private void TimImage_Tick(object sender, EventArgs e)
        {
            timImage.Stop();
            var pt = dgv.PointToClient(Cursor.Position);
            var idxRow = (pt.Y - dgv.ColumnHeadersHeight) / dgv.RowTemplate.Height;
            if (imageRowIndex == idxRow && pt.X > dgv.Width - dgvcImage.Width && pt.X < Width)
            {
                var drv = dgv.Rows[idxRow].DataBoundItem as DataRowView;
                if (drv?.Row is WebPagesRow page)
                {
                    var filePath = ImageFilePath(page.Id);
                    if (File.Exists(filePath))
                        ShowImage(page.Id);
                }
            }
            else
                imageRowIndex = -1;
        }

        private void BtnMaxiReplaceHash_Click(object sender, EventArgs e)
        {
            // This method replaces the "sha256Hash" part of the URL with the text from the clipboard.
            // It assumes that the URL contains "sha256Hash" and that the clipboard contains the new hash value.
            // Get new "sha256Hash": Chrome, DevTools, Network tab, Fetch/XHR, ...operationName=ProductDetails link
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    var drv = row.DataBoundItem as DataRowView;
                    if (!row.IsNewRow && drv?.Row is WebPagesRow page && page.URL.Contains("maxi.rs"))
                    {
                        var url = page.URL;
                        var idx = url.IndexOf("sha256Hash", StringComparison.Ordinal);
                        if (idx >= 0)
                            page.URL = url.Substring(0, idx) + "sha256Hash" + Clipboard.GetText();
                    }
                }
                MessageBox.Show("Done.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public WebPagesRow? CurrentWebPage
        {
            get
            {
                var drv = bs.Current as DataRowView;
                return drv?.Row as WebPagesRow;
            }
        }
    }
}
