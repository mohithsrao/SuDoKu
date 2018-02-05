using MSR.SuDoKu.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSR.Components
{
    public class Point : IPoint
    {
        public int X
        {
            get;

            set;
        }

        public int Y
        {
            get;

            set;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
