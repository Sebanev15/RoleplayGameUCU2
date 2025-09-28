using Library.Items;

namespace Ucu.Poo.RoleplayGame;

public class Spell : IItem
{
    public int AttackValue { get; set; }

    public int DefenseValue { get; set; }

    public bool IsMagical
    {
        get
        {
            return true;
        }
        set
        {
            
        }
    }

    public Spell(int attackValue, int defenseValue)
    {
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
    }
}
