using ICMPdfGenerator.Models.Data.CellElements;

namespace ICMPdfGenerator.Models.Data
{
    public class Cell : ICellElement
    {
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
