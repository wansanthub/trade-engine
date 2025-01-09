using TradeEngine.Core.Enums;
using TradeEngine.Core.Entities;

namespace TradeEngine.Tests;

public class TradeTests
{
        [Fact]
        public void ShouldCategorizeTradeCorrectly()
        {
            var trade = new Trade(1500000, ClientSectorEnum.Private, new DateTime(2025, 10, 1),new DateTime(2025, 10, 1));

            Assert.Equal("HighRisk", trade.Category.Name);
        }
}