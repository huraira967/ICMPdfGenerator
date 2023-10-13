﻿namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Padding
    {
        public float PaddingBottom { get; set; }
        public Padding SetPaddingBottom(float paddingBottom)
        {
            PaddingBottom = paddingBottom;
            return this;
        }
        public float GetPaddingBottom() => PaddingBottom;

    }
}
