using System;
using Xunit;
using StockJocky.Domain.Factory;
using StockJocky.Domain.Models;
using System.Threading.Tasks;

namespace StockJocky.Testing
{
    public class StockFactoryTest
    {
     StockFactory sf = new StockFactory();

        [Fact]
        public async Task FindStock()
        {
            ApiHelper.InitializeClient();

            StockSymbol ss =await sf.FindStock("AMAZON.COM INC", "AMZN");

            Assert.Equal("AMZN", ss.Symbol);
        }

        [Fact]
        public async Task StockFactoryDefault()
        {
            ApiHelper.InitializeClient();

            Stock msft = await sf.LoadStock();

            Assert.Equal("MSFT", msft.Symbol);
        }

        [Fact]
        public async Task StockFactoryWithArgumentTest()
        {
            ApiHelper.InitializeClient();

            Stock stock = await sf.LoadStock("amzn");

            Assert.Equal("AMZN", stock.Symbol);
        }
    }
}
