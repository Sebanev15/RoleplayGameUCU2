using Library.Items;
using Ucu.Poo.RoleplayGame;

namespace Library.Characters;

public class Dwarf:ICharacter
{
    public Dwarf(string name, int attackValue, int defenseValue)
    {
        this.Name = name;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.Health = this.health;
        this.Items = new List<IItem>();
    }
    private int health = 100;
    public string Name { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public List<IItem> Items { get;}

    public int Health
    {
        get
        {
            return this.health;
        } 
        set
        {
            this.health = value < 0 ? 0 : value;
        }
    }

    public void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }

    public void Heal()
    {
        this.Health = 100;
    }
    public void AddItem(IItem itemAdded)
    {
        if (!Items.Contains(itemAdded))
        {
            foreach (IItem item in Items)
            {
                if (item.GetType() == itemAdded.GetType())
                {
                    Console.WriteLine($"WARNING: Ya existia un {item.GetType()}, se procedio a añadir el nuevo item y se elimino el anterior");
                    Items.Remove(item);
                    Items.Add(itemAdded);
                    return;
                }
            }
            
            this.Items.Add(itemAdded);
        }
        else
        {
            
            Console.WriteLine($"{this.Name} ya tiene un {itemAdded.GetType().Name} ");
        }

    }
    
    public int GetTotalAttack()
    {
        int totalAttack = this.AttackValue;
        foreach (IItem item in this.Items)
        {
            if (item is Axe || item is Sword)
            {
                totalAttack += item.AttackValue*2;    
            }
            else
            {
                totalAttack += item.AttackValue;
            }
            
        }
        return totalAttack;
    }
    
    public int GetTotalDefense()
    {
        int totalDefense = this.DefenseValue;
        foreach (IItem item in this.Items)
        {
            if (item is Axe || item is Sword)
            {
                totalDefense += item.DefenseValue * 2;
            }
            else
            {
                totalDefense += item.DefenseValue;
            }
        }
        return totalDefense;
    }
    
    public void RemoveItem(IItem itemRemoved)
    {
        if(this.Items.Contains(itemRemoved))
        {
            if (itemRemoved is Axe)
            {
                itemRemoved.AttackValue *= 2;
                itemRemoved.DefenseValue *= 2;
            }
            this.Items.Remove(itemRemoved);
        }
        else
        {
            Console.WriteLine("ERROR " + this.Name + " no tenia un/a " + itemRemoved.GetType().Name);
        }
    }
    
}
