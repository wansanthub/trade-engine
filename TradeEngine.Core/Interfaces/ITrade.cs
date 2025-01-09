using TradeEngine.Core.Enums;

namespace TradeEngine.Core.Interfaces
{
    public interface ITrade
    {
        double Value { get; }
        ClientSectorEnum ClientSector { get; }
        DateTime NextPaymentDate { get; }
        Entities.TradeCategory Category { get; }
        ICategoryRule[] LoadCategoryRules();
    }
}