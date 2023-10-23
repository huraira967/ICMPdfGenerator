using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.Models.ICMPdfElements
{
    public class Table : ICellElement
    {
        private int Columns { get; set; }
        public Style Styles { get; set; } = new();
        private List<Cell> cells { get; set; }
        public Table(int coulmns)
        {
            Columns = coulmns;
            cells = new List<Cell>();
        }
        public Table Add(Cell cell)
        {
            cells.Add(cell);
            return this;
        }
        public Table AddRow(List<Cell> cell)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));
            if (cells.Count > Columns) throw new ArgumentException("number of columns exceeds the column limit");

            cell.AddRange(cells);
            return this;
        }
        public IList<Cell> GetCells() => cells;
        public int GetColumns() => Columns;


    }
}
