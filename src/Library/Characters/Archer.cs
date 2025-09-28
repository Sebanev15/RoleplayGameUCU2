namespace Ucu.Poo.RoleplayGame;
using Library.Items;

public class Archer
{
    private int health;
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
    public Archer(string name, int attackValue, int defenseValue, int maxHealth)
    {
        this.Name = name;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.health = maxHealth;
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
            totalAttack += item.AttackValue;
        }
        return totalAttack;
    }
    
    public int GetTotalDefense()
    {
        int totalDefense = this.DefenseValue;
        foreach (IItem item in this.Items)
        {
            totalDefense += item.DefenseValue;
        }
        return totalDefense;
    }
    
    public void Heal()
    {
        this.Health = health;
    }
    
    public void AddItem(IItem item)
    {    
        IItem existente = null;
        
        foreach (IItem i in Items)
        {
            if (i.GetType() == item.GetType())
            {
                existente = i;
                break;
            }
        }

        if (existente != null)
        {
            Items.Remove(existente);
            Items.Add(item);    
        }
        else
        {
            Items.Add(item);
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
