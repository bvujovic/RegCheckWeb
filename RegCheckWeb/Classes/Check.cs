﻿namespace RegCheckWeb.Classes
{
    public class Check(string url, string targetStrings)
    {
        public string URL { get; set; } = url;
        public string TargetStrings { get; set; } = targetStrings;

        public override string ToString()
        {
            return $"{URL}, target: {TargetStrings}";
        }

        public async Task<IEnumerable<string>> FindTarget()
        {
            if (string.IsNullOrEmpty(TargetStrings))
                return [];
            var html = await WebApi.Get(URL);
            var hits = new List<string>();
            var targets = TargetStrings.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            foreach (var target in targets)
                if (html.Contains(target))
                    hits.Add(target);
            return hits;
        }
    }
}
