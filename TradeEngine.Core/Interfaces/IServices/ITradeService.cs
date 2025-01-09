using TradeEngine.Core.Enums;

namespace TradeEngine.Core.Interfaces.IServices
{
    public interface ITradeService
    {
        (DateTime referenceDate, List<(double Value, ClientSectorEnum ClientSector, DateTime NextPaymentDate)> trades) ReadTradesFromFile();
    }
}