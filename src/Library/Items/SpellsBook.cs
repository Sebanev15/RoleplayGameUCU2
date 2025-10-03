using Library.Items;

namespace Ucu.Poo.RoleplayGame;

public class SpellsBook : IItem
{
    public List<Spell> Spells = new List<Spell>();
    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (Spell spell in this.Spells)
            {
                value += spell.AttackValue;
            }
            return value;
        }
        set
        {
            
        }
    }

    public int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (Spell spell in this.Spells)
            {
                value += spell.DefenseValue;
            }
            return value;
        }
        set
        {
            
        }
    }

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

    public void AddSpell(Spell spell)
    {
        if (!Spells.Contains(spell))
        {
            Spells.Add(spell);    
        }
        else
        {
            Console.WriteLine("ERROR: este libro ya contiene el hechizo");
        }
        
    }

    public void RemoveSpell(Spell spell)
    {
        if (this.Spells.Contains(spell))
        {
            Spells.Remove(spell);
        }
        else
        {
            Console.WriteLine($"El libro de hechizos no tiene el hechizo {spell}");
        }
    }
}
