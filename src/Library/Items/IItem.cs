namespace Library.Items;

public interface IItem
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public bool IsMagical { get; set; }
}