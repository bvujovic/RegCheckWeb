namespace RegCheckWeb.Classes
{
    public static class WebApi
    {
        public static async Task<string> Get(string url)
        {
            return await GetHttpClient().GetStringAsync(url);
        }

        private static HttpClient? httpClient = null;

        private static HttpClient GetHttpClient()
        {
            if (httpClient != null)
                return httpClient;
            httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(5) };
            return httpClient;
        }
    }
}
