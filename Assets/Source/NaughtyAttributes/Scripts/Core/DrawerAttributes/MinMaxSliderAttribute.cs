﻿using System;

namespace NaughtyAttributes.Scripts.Core.DrawerAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MinMaxSliderAttribute : DrawerAttribute
    {
        public MinMaxSliderAttribute(float minValue, float maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public float MinValue { get; private set; }
        public float MaxValue { get; private set; }
    }
}