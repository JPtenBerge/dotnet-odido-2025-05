namespace Odido.ConsoleApplication;

internal class Boss : Character
{
    public int Level { get; set; }
    public Boss() : this("Boss")
    {
    }
    public Boss(string name) : base(name)
    {
        Type = "Boss";
        Level = 1;
    }
}
