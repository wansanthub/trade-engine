using TradeEngine.Core.Enums;
using TradeEngine.Core.Interfaces;
using TradeEngine.Core.Rules;

namespace TradeEngine.Core.Entities
{
    public class Trade : ITrade
    {
        public double Value { get; }
        public ClientSectorEnum ClientSector { get; }
        public DateTime NextPaymentDate { get; }
        public TradeCategory Category { get; private set; } 

        public Trade(double value, ClientSectorEnum clientSector, DateTime nextPaymentDate, DateTime referenceDate)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
            Category = ApplyRules(referenceDate);
        }

        public ICategoryRule[] LoadCategoryRules()
        {
            return
            [
                new ExpiredRule(),
                new HighRiskRule(),
                new MediumRiskRule()
            ];
        }

        TradeCategory ApplyRules(DateTime referenceDate)
        {

            foreach (var rule in LoadCategoryRules())
            {
                if (rule.IsMatch(this, referenceDate))
                {
                    Category = new TradeCategory(rule.Name);
                    return Category;
                }
            }

            return Category;
        }
    }
}