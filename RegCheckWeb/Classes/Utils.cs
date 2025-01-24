using System.Diagnostics;

namespace RegCheckWeb.Classes
{
    public static class Utils
    {
        public static void GoToLink(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = "chrome",
                    Arguments = url,
                });
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Go to Link"); }
        }
    }
}
