using System;

namespace NaughtyAttributes.Scripts.Core.DrawerAttributes_SpecialCase
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ShowNonSerializedFieldAttribute : SpecialCaseDrawerAttribute
    {
    }
}