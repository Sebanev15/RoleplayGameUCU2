namespace Ucu.Poo.RoleplayGame;
using Library.Items;

public class Archer
{
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
        private set
        {
            this.health = value < 0 ? 0 : value;
        }
    }
    public Archer(string name, int attackValue, int defenseValue)
    {
        this.Name = name;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.Health = this.health;
        this.Items = new List<IItem>();
    }
    public void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }

    public int GetTotalAttack()
    {
        int totalAttack = this.AttackValue;
        foreach (IItem item in this.Items)
        {
            if (item is Bow)
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
            if (item is Bow)
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
    
    public void RemoveItem(IItem item)

    {
        if(this.Items.Contains(item))
        {
            
            this.Items.Remove(item);
        }
        else
        {
            Console.WriteLine($"{this.Name} no tenía un {item.GetType().Name}");
        }
    }
}
