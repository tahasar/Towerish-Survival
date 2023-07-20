using System;

namespace NaughtyAttributes.Scripts.Core.MetaAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BoxGroupAttribute : MetaAttribute, IGroupAttribute
    {
        public BoxGroupAttribute(string name = "")
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}