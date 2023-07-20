﻿using System;

namespace NaughtyAttributes.Scripts.Core.DrawerAttributes
{
    public enum EInfoBoxType
    {
        Normal,
        Warning,
        Error
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InfoBoxAttribute : DrawerAttribute
    {
        public InfoBoxAttribute(string text, EInfoBoxType type = EInfoBoxType.Normal)
        {
            Text = text;
            Type = type;
        }

        public string Text { get; private set; }
        public EInfoBoxType Type { get; private set; }
    }
}