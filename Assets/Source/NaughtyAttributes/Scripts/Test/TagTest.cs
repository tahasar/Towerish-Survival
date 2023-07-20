using System;
using NaughtyAttributes.Scripts.Core.DrawerAttributes;
using NaughtyAttributes.Scripts.Core.DrawerAttributes_SpecialCase;
using UnityEngine;

namespace NaughtyAttributes.Scripts.Test
{
    public class TagTest : MonoBehaviour
    {
        [Tag] public string tag0;

        public TagNest1 nest1;

        [Button]
        private void LogTag0()
        {
            Debug.Log(tag0);
        }
    }

    [Serializable]
    public class TagNest1
    {
        [Tag] public string tag1;

        public TagNest2 nest2;
    }

    [Serializable]
    public struct TagNest2
    {
        [Tag] public string tag2;
    }
}