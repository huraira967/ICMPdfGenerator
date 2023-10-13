using ICMPdfGenerator.Models.Data.CellElements;

namespace ICMPdfGenerator.Models.Data
{
    public class Table : ICellElement
    {
        private int Columns { get; set; }
       
        private List<ICellElement> cells { get; set; }
        public Table(int coulmns) 
        { 
            Columns = coulmns;
            cells = new List<ICellElement>();
        }
        public Table Add(ICellElement cell)
        {
            cells.Add(cell);
            return this;
        }
        public Table AddRow(List<ICellElement> cell)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));
            if (cells.Count > Columns) throw new ArgumentException("number of columns exceeds the column limit");

            cell.AddRange(cells);
            return this;
        }
        public IList<ICellElement> GetCells() => cells; 
        public int GetColumns() => Columns;


    }
}
