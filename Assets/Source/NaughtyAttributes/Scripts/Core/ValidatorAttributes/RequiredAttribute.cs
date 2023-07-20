using System;

namespace NaughtyAttributes.Scripts.Core.ValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RequiredAttribute : ValidatorAttribute
    {
        public RequiredAttribute(string message = null)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}