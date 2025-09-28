namespace Ucu.Poo.RoleplayGame;
using Library.Items;

public class Knight:ICharacter
{
    private int health = 100;

    public Knight(string name, int maxHealth)
    {
        this.Name = name;
        this.health = maxHealth;
        this.Health = this.health;
        this.Items = new List<IItem>();
    }

    public string Name { get; set; }

    public Sword Sword { get; set; }

    public Shield Shield { get; set; }

    public Armor Armor { get; set; }
    public List<IItem> Items { get;}

    public int AttackValue
    {
        get
        {
            return Sword.AttackValue;
        }
        set
        {}
    }

    public int DefenseValue
    {
        get
        {
            return Armor.DefenseValue + Shield.DefenseValue;
        }
        set
        {}
    }

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
        // Los caballeros no pueden tener items mágicos, por lo cual solo se añade un item si IsMagical == false
        if (!Items.Contains(itemAdded))
        {
            
            this.Items.Add(itemAdded);
        }
        else
        {
            Console.WriteLine($"{this.Name} ya tiene un {itemAdded.GetType().Name}");
        }
        
        if (!itemAdded.IsMagical)
        {
            this.Items.Add(itemAdded);
        }
        else
        {
            Console.WriteLine($"{this.Name} ya tiene un {itemAdded.GetType().Name}");
        }
    }
    
    public void RemoveItem(IItem itemRemoved)
    {
        if(this.Items.Contains(itemRemoved))
        {
            this.Items.Remove(itemRemoved);
        }
        else
        {
            Console.WriteLine("ERROR " + this.Name + " no tenia un/a " + itemRemoved.GetType().Name);
        }
    }
}
