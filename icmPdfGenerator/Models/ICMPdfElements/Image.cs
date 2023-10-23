using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.Models.ICMPdfElements
{
    public class Image : ICellElement
    {
        public Stream? ImageStream { get; set; }
        public string? ImagePath { get; set; }
        private byte[]? ImageBytes { get; set; }
        public Style Styles { get; set; } = new Style();
        public Image(FileStream? imageStream)
        {
            ImageStream = imageStream ?? throw new NullReferenceException(nameof(imageStream));

            byte[] byteArray = new byte[imageStream.Length];
            int bytesRead = imageStream.Read(byteArray, 0, (int)imageStream.Length);

            if (bytesRead == imageStream.Length)
            {
                ImageBytes = byteArray;
            }
        }
        public Image(string imagePath)
        {
            ImagePath = !string.IsNullOrEmpty(imagePath) ? imagePath : throw new NullReferenceException(nameof(imagePath));

            using FileStream imageFileStream = new(imagePath, FileMode.Open, FileAccess.Read);
            byte[] byteArray = new byte[imageFileStream.Length];

            int bytesRead = imageFileStream.Read(byteArray, 0, (int)imageFileStream.Length);

            if (bytesRead == imageFileStream.Length)
            {
                ImageBytes = byteArray;
            }
        }
        public Image(byte[] imageBytes) => ImageBytes = imageBytes;
        public byte[]? GetImageBytes() => ImageBytes;
    }
}
