using System;

namespace NaughtyAttributes.Scripts.Core.ValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ValidateInputAttribute : ValidatorAttribute
    {
        public ValidateInputAttribute(string callbackName, string message = null)
        {
            CallbackName = callbackName;
            Message = message;
        }

        public string CallbackName { get; private set; }
        public string Message { get; private set; }
    }
}