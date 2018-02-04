namespace MSR.SuDoKu.Interfaces
{
    public interface ICell
    {
        int? Value { get; set; }

        IPoint Point { get; set; }

        IPoint ParentPoint { get; set; }
    }
}
