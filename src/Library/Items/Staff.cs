using Library.Items;

namespace Ucu.Poo.RoleplayGame;

public class Staff: IItem
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public bool IsMagical { get; set; }

    public Staff(int attackValue, int defenseValue, bool isMagical)
    {
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.IsMagical = isMagical;
    }
}
