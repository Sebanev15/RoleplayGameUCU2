using Library.Items;

namespace Ucu.Poo.RoleplayGame;

public class Helmet : IItem
{
    public int AttackValue { get; set; }

    public bool IsMagical { get; set; }

    public int DefenseValue { get; set; }

    public Helmet(bool isMagical, int attackValue, int defenseValue)
    {
        this.IsMagical = isMagical;
        this.DefenseValue = defenseValue;
        this.AttackValue = attackValue;
    }
}
