namespace ICMPdfGenerator.Models.Data.CellElements
{
    public class Image : ICellElement
    {
        private byte[] _image { get; set; }
        private float Height { get; set; }
        private float Width { get; set; }

        public Image Add(byte[] image)
        {
            _image = image;
            return this;
        }
        public Image SetHeight(float height)
        {
            this.Height = height;
            return this;
        }
        public Image SetWidth(float width)
        {
            this.Width = width;
            return this;
        }
        public float GetHeight() => this.Height;
        public float GetWidth() => this.Width;
        public byte[] GetImageBytes() => this._image;
    }
}
