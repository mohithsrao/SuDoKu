using MSR.SuDoKu.Interfaces.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSR.SuDoKu.Grid
{
    public class SuDoKuGridCreator
    {
        public ISuDoKuGrid Create(int size, params int?[] valueList)
        {
            var cellCount = Math.Pow(size * size, 2);
            if (valueList.Count() != cellCount)
            {
                throw new ArgumentException("The Size of ValueList paramenter is not equal to the total size of the array", "valueList");
            }
            
            ISuDoKuGrid sGrid = new SuDoKuGrid(size);
            for (int i = 0; i < valueList.Count(); i++)
            {
                var xgridLocation = i / (size * size * size);
                var ygridLocation = (i % (size * size)) / size;

                var XCell = (i / (size * size) % size);
                var YCell = i % size;

                var grid = sGrid.Grid[xgridLocation, ygridLocation];

                var cell = grid.Cells[XCell, YCell];

                cell.Value = valueList[i];
            }

            return sGrid;
        }
    }
}
