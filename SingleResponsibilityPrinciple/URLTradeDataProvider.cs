using SingleResponsibilityPrinciple.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SingleResponsibilityPrinciple
{
    public class URLTradeDataProvider : ITradeDataProvider
    {
        private readonly string url;

        public URLTradeDataProvider(string url)
        {
            this.url = url;
        }

        public IEnumerable<string> GetURLTradeData(string url)
        {
            var tradeData = new List<string>();
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }
    }
}
