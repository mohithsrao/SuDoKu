﻿namespace MSR.Components.Grid.Cell
{
    public interface ICell
    {
        int? Value { get; set; }
        int X_Cord { get; set; }
        int Y_Cord { get; set; }
    }
}