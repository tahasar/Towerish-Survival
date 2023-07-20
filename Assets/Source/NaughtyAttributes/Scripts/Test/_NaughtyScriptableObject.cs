using System.Collections.Generic;
using NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEngine;

namespace NaughtyAttributes.Scripts.Test
{
    //[CreateAssetMenu(fileName = "NaughtyScriptableObject", menuName = "NaughtyAttributes/_NaughtyScriptableObject")]
    public class _NaughtyScriptableObject : ScriptableObject
    {
        [Expandable] public List<_TestScriptableObjectA> listA;
    }
}