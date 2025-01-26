using System.Data;
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

        public static Ds Ds { get; set; }

        public static void SaveSetting(string name, string value)
        {
            var loc = Ds.Settings.FindByName(name);
            if (loc == null)
            {
                loc = Ds.Settings.NewSettingsRow();
                loc.Name = name;
            }
            loc.Value = value;
            if (loc.RowState == DataRowState.Detached)
                Ds.Settings.AddSettingsRow(loc);
        }

        public static int ReadIntSetting(string name, int defValue)
        {
            var s = Ds.Settings.FindByName(name);
            if (s != null)
                return int.Parse(s.Value);
            return defValue;
        }
    }
}
