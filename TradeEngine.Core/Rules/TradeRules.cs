using TradeEngine.Core.Entities;
using TradeEngine.Core.Enums;
using TradeEngine.Core.Interfaces;

namespace TradeEngine.Core.Rules
{
    public class ExpiredRule : ICategoryRule
    {
        public string Name => "Expired";

        public bool IsMatch(Trade trade, params object[] args)
        {
        if (args.Length > 0 && args[0] is DateTime referenceDate)
        {
            return (referenceDate - trade.NextPaymentDate).TotalDays > 30;
        }

        throw new ArgumentException("Reference date is required for expiration check.");
        }
    }

    public class HighRiskRule : ICategoryRule
    {
        public string Name => "HighRisk";

        public bool IsMatch(Trade trade, params object[] args)
        {
            return trade.Value > 1_000_000 && trade.ClientSector == ClientSectorEnum.Private;
        }
    }

    public class MediumRiskRule : ICategoryRule
    {
        public string Name => "MediumRisk";

        public bool IsMatch(Trade trade, params object[] args)
        {
            return trade.Value > 1_000_000 && trade.ClientSector == ClientSectorEnum.Public;
        }
    }
}