using TradeEngine.Core.Entities;

namespace TradeEngine.Core.Interfaces
{
    public interface ICategoryRule
    {
        string Name { get; }
        bool IsMatch(Trade trade, params object[] args);
    }
}