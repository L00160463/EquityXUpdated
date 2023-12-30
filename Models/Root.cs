using System.Collections.Generic;

namespace EquityX_L00160463.Models
{
    public class Root
    {
        public QuoteResponse quoteResponse { get; set; }
    }

    public class QuoteResponse
    {
        public List<Result> result { get; set; }
    }

    public class Result
    {
        public string symbol { get; set; }
        public string displayName { get; set; }
        public double regularMarketPrice { get; set; }
        public double regularMarketChangePercent { get; set; }
        public double fiftyTwoWeekLow { get; set; }
        public double fiftyTwoWeekHigh { get; set; }
        public string coinImageUrl { get; set; }
        public string shortName { get; set; }
        public string quoteType { get; set; }
        public string marketState { get; set; }
        public string regularMarketChange { get; set; }
        public string regularMarketOpen { get; set; }
        public string regularMarketDayHigh { get; set; }


    }
}
