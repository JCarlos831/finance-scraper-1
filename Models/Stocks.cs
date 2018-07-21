namespace finance_scraper_1.Models
{
    public class Stocks
    {
            public int Id { get; set; }
            public string Symbol { get; set; }
            public string LastPrice { get; set; }
            public string Change { get; set; }
            public string PercentChange { get; set; }
            public string MarketTime { get; set; }
            public string Volume { get; set; }
            public string Shares { get; set; }
            public string AvgVol { get; set; }
            public string MarketCap { get; set; }
            public string Date { get; set; }
    }
}