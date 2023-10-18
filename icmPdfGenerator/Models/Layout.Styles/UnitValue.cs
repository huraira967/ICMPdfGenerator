namespace ICMPdfGenerator.Models.Layout.Styles
{
    public class UnitValue
    {
        public float Value { get; set; }
        public bool IsPercentage { get; set; }
        public bool IsAbsolute { get; set; }
        public UnitValue(float value, bool isPercenatge, bool isAbsolute)
        {
            Value = value;
            IsPercentage = isPercenatge;
            IsAbsolute = isAbsolute;
        }
    }
}
