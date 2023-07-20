using System.Collections.Generic;
using NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEngine;

namespace NaughtyAttributes.Scripts.Test
{
    //[CreateAssetMenu(fileName = "TestScriptableObjectA", menuName = "NaughtyAttributes/TestScriptableObjectA")]
    public class _TestScriptableObjectA : ScriptableObject
    {
        [Expandable] public List<_TestScriptableObjectB> listB;
    }
}