namespace Library.Items;

public class Armor:IItem
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public bool IsMagical { get; set; }

    public Armor(int attackValue, int defenseValue, bool isMagical)
    {
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.IsMagical = isMagical;

    }

}