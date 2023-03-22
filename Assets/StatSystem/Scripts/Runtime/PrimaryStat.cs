using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StatSystem.Tests")]
namespace StatSystem
{
    public class PrimaryStat : Stat
    {
        private float m_Basevalue;
        public override float baseValue => m_Basevalue;

        public PrimaryStat(StatDefinition definition) : base(definition)
        {
            m_Basevalue = definition.baseValue;
            CalculateValue();
        }

        internal void Add(float amount)
        {
            m_Basevalue += amount;
            CalculateValue();
        }

        internal void Substract(float amount)
        {
            m_Basevalue -= amount;
            CalculateValue();
        }
    }
}