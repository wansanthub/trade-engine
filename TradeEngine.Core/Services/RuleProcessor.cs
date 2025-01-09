using TradeEngine.Core.Entities;
using TradeEngine.Core.Interfaces;

namespace TradeEngine.Core.Services
{
    public class RuleProcessor
    {
        private readonly IEnumerable<ICategoryRule> _rules;

        public RuleProcessor(IEnumerable<ICategoryRule> rules)
        {
            _rules = rules;
        }

        public TradeCategory Categorize(Trade trade, DateTime referenceDate)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(trade, referenceDate))
                {
                    return new TradeCategory(rule.Name);
                }
            }

            return new TradeCategory("Undefined");
        }
    }
}