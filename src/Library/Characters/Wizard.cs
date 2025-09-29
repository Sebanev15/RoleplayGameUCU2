namespace Ucu.Poo.RoleplayGame;
using Library.Items;

public class Wizard: ICharacter
{
    public Wizard(string name, int attackValue, int defenseValue, int maxHealth)
    {
        this.Name = name;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.health = maxHealth;
        this.Health = this.health;
        this.Items = new List<IItem>();
    }
    
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
        this.Health = health;
    }
    public void AddItem(IItem itemAdded)
    {
        // Los magos solo pueden tener items magicos, por lo que no deberia de poder tener un item no magico
        if (!Items.Contains(itemAdded) && itemAdded.IsMagical)
        {
            
            this.Items.Add(itemAdded);
        }
        else
        {
            Console.WriteLine($"{this.Name} ya tiene un {itemAdded.GetType().Name} o no es un objeto magico");
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
