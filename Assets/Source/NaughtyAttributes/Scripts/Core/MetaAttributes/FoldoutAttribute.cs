using System;

namespace NaughtyAttributes.Scripts.Core.MetaAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FoldoutAttribute : MetaAttribute, IGroupAttribute
    {
        public FoldoutAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}