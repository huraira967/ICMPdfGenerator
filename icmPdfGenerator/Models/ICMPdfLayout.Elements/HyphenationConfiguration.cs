namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public class HyphenationConfiguration
    {
        public int Left { get; set; }
        public int Right { get; set; }
        //
        // Summary:
        //     Constructs a new iText.ICMPdfLayout.Hyphenation.HyphenationConfig.
        //
        // Parameters:
        //   leftMin:
        //     the minimum number of characters before the hyphenation point
        //
        //   rightMin:
        //     the minimum number of characters after the hyphenation point
        //
        // Remarks:
        //     Constructs a new iText.ICMPdfLayout.Hyphenation.HyphenationConfig . No language hyphenation
        //     files will be used. Only soft hyphen symbols ('\u00ad') will be taken into account.
        public HyphenationConfiguration(int left, int right)
        {
            Left = left;
            Right = right;
        }
    }
}
