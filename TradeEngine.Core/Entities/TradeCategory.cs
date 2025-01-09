namespace TradeEngine.Core.Entities
{
    public class TradeCategory
    {
        public string Name { get; }

        public TradeCategory(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}