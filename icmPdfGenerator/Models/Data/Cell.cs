using ICMPdfGenerator.Models.Data.CellElements;
using ICMPdfGenerator.Models.Layout.Styles;

namespace ICMPdfGenerator.Models.Data
{
    public class Cell : ICellElement
    {
        public Style Styles { get; set; } = new();
        private List<ICellElement> CellElements { get; set; }
        public Cell()
        {
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
