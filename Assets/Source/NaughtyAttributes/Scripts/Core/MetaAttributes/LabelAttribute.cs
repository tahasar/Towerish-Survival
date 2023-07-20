using System;

namespace NaughtyAttributes.Scripts.Core.MetaAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class LabelAttribute : MetaAttribute
    {
        public LabelAttribute(string label)
        {
            Label = label;
        }

        public string Label { get; private set; }
    }
}