
using MSR.SuDoKu.Interfaces;

namespace MSR.Components
{
    public class Cell : ICell
    {
        public Cell(int x, int y)
        {
            X_Cord = x;
            Y_Cord = y;
        }

        public int? Value
        {
            get;

            set;
        }

        public int X_Cord
        {
            get;

            set;
        }

        public int Y_Cord
        {
            get;

            set;
        }
    }
}
