﻿using System;

namespace NaughtyAttributes.Scripts.Core.DrawerAttributes_SpecialCase
{
    public enum EButtonEnableMode
    {
        /// <summary>
        ///     Button should be active always
        /// </summary>
        Always,

        /// <summary>
        ///     Button should be active only in editor
        /// </summary>
        Editor,

        /// <summary>
        ///     Button should be active only in playmode
        /// </summary>
        Playmode
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : SpecialCaseDrawerAttribute
    {
        public ButtonAttribute(string text = null, EButtonEnableMode enabledMode = EButtonEnableMode.Always)
        {
            Text = text;
            SelectedEnableMode = enabledMode;
        }

        public string Text { get; private set; }
        public EButtonEnableMode SelectedEnableMode { get; private set; }
    }
}