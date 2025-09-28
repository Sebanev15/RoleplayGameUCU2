using Library.Items;

namespace Ucu.Poo.RoleplayGame;

public class Sword:IItem
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public bool IsMagical { get; set; }

    public Sword(int attackValue, int defenseValue, bool isMagical)
    {
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.IsMagical = isMagical;

    }
}
