namespace StatSystem
{
    public class PrimaryStats : Stat
    {
        private int m_BaseValue;
        public override int baseValue => m_BaseValue;
        
        public PrimaryStats(StatDefinition definition) : base(definition)
        {
            m_BaseValue = definition.baseValue;
            CalculateValue();
        }
        
        internal void Add(int amount)
        {
            m_BaseValue += amount;
            CalculateValue();
        }

        internal void Substract(int amount)
        {
            m_BaseValue -= amount;
            CalculateValue();
        }
    }
}