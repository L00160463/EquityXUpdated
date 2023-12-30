using System;
using System.Collections.ObjectModel;

namespace EquityX_L00160463.Models
{
    public class Asset
    {


        public string Symbol { get; set; }

        public string ShortName { get; set; }
        public string DisplayName { get; set; }
        public double RegularMarketPrice { get; set; }
        public double RegularMarketChangePercent { get; set; }
        public double FiftyTwoWeekLow { get; set; }
        public double FiftyTwoWeekHigh { get; set; }
        public string CoinImageUrl { get; set; }
        public string QuoteType { get; set; }
        public string MarketState { get; set; }
        public string RegularMarketChange { get; set; }
        public string RegularMarketOpen { get; set; }
        public string RegularMarketDayHigh { get; set; }





    }


}
