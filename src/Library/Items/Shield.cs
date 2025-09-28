using Library.Items;

namespace Ucu.Poo.RoleplayGame;

public class Shield:IItem
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public bool IsMagical { get; set; }

    public Shield(int attackValue, int defenseValue, bool isMagical)
    {
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.IsMagical = isMagical;

    }
}
