namespace finance_scraper_1.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

        public static class SeedData
        {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new MvcStockContext(
                    serviceProvider.GetRequiredService<DbContextOptions<MvcStockContext>>()))
                {
                    // Look for any movies.
                    if (context.Stocks.Any())
                    {
                        return;   // DB has been seeded
                    }

                    context.Stocks.AddRange(
                        new Stocks
                        {
                            Symbol = "AAPL",
                            LastPrice = "191.44",
                            Change = "-0.44",
                            PercentChange = "-0.23%",
                            MarketTime = "Jul 20 EDT",
                            Volume = "16.17M",
                            Shares = "-",
                            AvgVol = "-",
                            MarketCap = "25.21M",
                            Date = "7/21/2018"
                        },

                        new Stocks
                        {
                            Symbol = "CVS",
                            LastPrice = "65.26",
                            Change = "-0.88",
                            PercentChange = "-1.33%",
                            MarketTime = "Jul 20 EDT",
                            Volume = "6.34M",
                            Shares = "-",
                            AvgVol = "-",
                            MarketCap = "8.75M",
                            Date = "7/21/2018"
                        },

                        new Stocks
                        {
                            Symbol = "GOOG",
                            LastPrice = "191.44",
                            Change = "-0.44",
                            PercentChange = "-0.23%",
                            MarketTime = "Jul 20 EDT",
                            Volume = "16.17M",
                            Shares = "-",
                            AvgVol = "-",
                            MarketCap = "25.21M",
                            Date = "7/21/2018"
                        },

                        new Stocks
                        {
                            Symbol = "FB",
                            LastPrice = "191.44",
                            Change = "-0.44",
                            PercentChange = "-0.23%",
                            MarketTime = "Jul 20 EDT",
                            Volume = "16.17M",
                            Shares = "-",
                            AvgVol = "-",
                            MarketCap = "25.21M",
                            Date = "7/21/2018"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }