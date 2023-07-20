﻿using System;

namespace NaughtyAttributes.Scripts.Core.DrawerAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ShowAssetPreviewAttribute : DrawerAttribute
    {
        public const int DefaultWidth = 64;
        public const int DefaultHeight = 64;

        public ShowAssetPreviewAttribute(int width = DefaultWidth, int height = DefaultHeight)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}