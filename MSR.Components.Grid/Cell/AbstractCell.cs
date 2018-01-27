namespace MSR.Components.Grid.Cell
{
    public abstract class AbstractCell
    {
        public AbstractCell(int x,int y)
        {
            X_Cord = x;
            Y_Cord = y;
        }

        public int X_Cord { get; set; }
        public int Y_Cord { get; set; }
    }
}
