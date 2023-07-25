namespace StatSystem
{
    public class PrimaryStat : Stat
    {
        private int m_BaseValue;
        public override int baseValue => m_BaseValue;
        
        public PrimaryStat(StatDefinition definition) : base(definition)
        {
            m_BaseValue = definition.baseValue;
            CalculateValue();
        }

        public void Add(int amount)
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