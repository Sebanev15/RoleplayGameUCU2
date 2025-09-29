using Library.Items;
using Ucu.Poo.RoleplayGame;

namespace Library.Characters;

public class Dwarf:ICharacter
{
    

    public Dwarf(string name, int attackValue, int defenseValue, int maxHealth)
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
        int newDefense = this.DefenseValue;
        if (newDefense<=0)
        {
            newDefense = 0;
        }

        if (this.Health<0)
        {
            this.Health = 0;
        }
        
        this.DefenseValue = newDefense;
    }

    public void Heal()
    {
        this.Health = health;
    }

    public void AddItem(IItem itemAdded)
    {

        foreach (IItem item in Items)
        {
            if (item.GetType().Name == itemAdded.GetType().Name)
            {
                return;
            }
        }
    if (!Items.Contains(itemAdded))
        {
            // A los enanos ser muy efectivos con armas cuerpo a cuerpo,
            // se le multipica la defensa y el ataque de dicho item si es de tipo Weapon
            if (itemAdded is Axe)
            {
                itemAdded.AttackValue *= 2;
                itemAdded.DefenseValue *= 2;
            }
            this.Items.Add(itemAdded);
        }
        else
        {
            Console.WriteLine($"{this.Name} ya tiene un {itemAdded.GetType().Name} ");
        }
    }
    
    public void RemoveItem(IItem itemRemoved)
    {
        if(this.Items.Contains(itemRemoved))
        {
            if (itemRemoved is Axe)
            {
                itemRemoved.AttackValue /= 2;
                itemRemoved.DefenseValue /= 2;
            }
            this.Items.Remove(itemRemoved);
        }
        else
        {
            Console.WriteLine("ERROR " + this.Name + " no tenia un/a " + itemRemoved.GetType().Name);
        }
        
        
        
        
    }
    
    public int GetTotalAttack()
    {
        int totalAttackDamage = this.AttackValue ;
        foreach (IItem item in Items)
        {
            totalAttackDamage+=item.AttackValue;
        }
        
        return totalAttackDamage;
    }
    
    public int GetTotalDefense()
    {
        int totalDefenseValue= this.DefenseValue ;
        foreach (IItem item in Items)
        {
            totalDefenseValue+=item.DefenseValue;
        }
        
        return totalDefenseValue;
    }
    
    
}
