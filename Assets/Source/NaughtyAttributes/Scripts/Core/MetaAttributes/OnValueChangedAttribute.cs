using System;

namespace NaughtyAttributes.Scripts.Core.MetaAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class OnValueChangedAttribute : MetaAttribute
    {
        public OnValueChangedAttribute(string callbackName)
        {
            CallbackName = callbackName;
        }

        public string CallbackName { get; private set; }
    }
}