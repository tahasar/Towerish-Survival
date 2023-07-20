using System;
using NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEngine;

namespace NaughtyAttributes.Scripts.Test
{
    public class MinMaxSliderTest : MonoBehaviour
    {
        [MinMaxSlider(0.0f, 1.0f)] public Vector2 minMaxSlider0 = new(0.25f, 0.75f);

        public MinMaxSliderNest1 nest1;
    }

    [Serializable]
    public class MinMaxSliderNest1
    {
        [MinMaxSlider(0.0f, 1.0f)] public Vector2 minMaxSlider1 = new(0.25f, 0.75f);

        public MinMaxSliderNest2 nest2;
    }

    [Serializable]
    public class MinMaxSliderNest2
    {
        [MinMaxSlider(1, 11)] public Vector2Int minMaxSlider2 = new(6, 11);
    }
}