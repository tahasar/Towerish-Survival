using NaughtyAttributes.Scripts.Core.ValidatorAttributes;
using NaughtyAttributes.Scripts.Editor.Utility;
using UnityEditor;

namespace NaughtyAttributes.Scripts.Editor.PropertyValidators
{
    public class RequiredPropertyValidator : PropertyValidatorBase
    {
        public override void ValidateProperty(SerializedProperty property)
        {
            var requiredAttribute = PropertyUtility.GetAttribute<RequiredAttribute>(property);

            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                if (property.objectReferenceValue == null)
                {
                    var errorMessage = property.name + " is required";
                    if (!string.IsNullOrEmpty(requiredAttribute.Message)) errorMessage = requiredAttribute.Message;

                    NaughtyEditorGUI.HelpBox_Layout(errorMessage, MessageType.Error,
                        property.serializedObject.targetObject);
                }
            }
            else
            {
                var warning = requiredAttribute.GetType().Name + " works only on reference types";
                NaughtyEditorGUI.HelpBox_Layout(warning, MessageType.Warning, property.serializedObject.targetObject);
            }
        }
    }
}