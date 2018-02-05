
using System;
using MSR.SuDoKu.Interfaces;

namespace MSR.Components
{
    public class Cell : ICell
    {
        public Cell(int x, int y, IPoint parentPoint)
        {
            Point = new Point() { X = x, Y = y };
            ParentPoint = parentPoint;
        }

        public IPoint ParentPoint
        {
            get;

            set;
        }

        public IPoint Point
        {
            get;

            set;
        }

        public int? Value
        {
            get;

            set;
        }

        public override string ToString()
        {
            return $"{Point} parent {ParentPoint} Value : {(Value.HasValue ? Value.Value.ToString() : "null")}";
        }
    }
}
