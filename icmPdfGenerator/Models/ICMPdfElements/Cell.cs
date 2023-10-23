using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.Models.ICMPdfElements
{
    public class Cell : ICellElement
    {
        public int RowSpan { get; } = 1;
        public int ColSpan { get; set; } = 1;
        public Style Styles { get; set; } = new();
        private List<ICellElement> CellElements { get; set; }
        public Cell(int colSpan, int rowSpan)
        {
            RowSpan = rowSpan;
            ColSpan = colSpan;
            CellElements = new List<ICellElement>();
        }
        public Cell()
        {
            RowSpan = 1;
            ColSpan = 1;
            CellElements = new List<ICellElement>();
        }
        public Cell Add(ICellElement cellElement)
        {
            CellElements.Add(cellElement);
            return this;
        }
        public IList<ICellElement> GetCellContent() => CellElements;
    }
}
