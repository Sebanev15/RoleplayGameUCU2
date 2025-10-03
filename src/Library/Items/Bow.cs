namespace Ucu.Poo.RoleplayGame;
using Library.Items;
public class Bow:IItem
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public bool IsMagical { get; set; }

    public Bow(int attackValue, int defenseValue, bool isMagical)
    {
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.IsMagical = isMagical;

    }
}
