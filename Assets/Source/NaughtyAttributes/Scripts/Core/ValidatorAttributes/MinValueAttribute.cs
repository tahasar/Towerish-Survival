using System;

namespace NaughtyAttributes.Scripts.Core.ValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MinValueAttribute : ValidatorAttribute
    {
        public MinValueAttribute(float minValue)
        {
            MinValue = minValue;
        }

        public MinValueAttribute(int minValue)
        {
            MinValue = minValue;
        }

        public float MinValue { get; private set; }
    }
}