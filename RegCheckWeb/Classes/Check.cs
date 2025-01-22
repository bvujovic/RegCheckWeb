namespace RegCheckWeb.Classes
{
    public class Check(string url, string targetString)
    {
        public string URL { get; set; } = url;
        public string TargetString { get; set; } = targetString;

        public override string ToString()
        {
            return $"{URL}, target: {TargetString}";
        }

        public async Task<bool> FindTarget()
        {
            var html = await WebApi.Get(URL);
            return html.Contains(TargetString);
        }
    }
}
