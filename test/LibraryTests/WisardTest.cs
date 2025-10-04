using Library.Items;
using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;

public class GenericCharacter : ICharacter
{
    public int Health { get; set; }
    public List<IItem> Items { get; }

    public int AttackValue { get; set; }

    public int DefenseValue { get; set; }
        
    public string Name { get; set; }

    public GenericCharacter(int health = 100, int attackValue = 10, int defenseValue = 10, string name = "Default Character")
    {
        this.Health = health;
        this.Items = [new GenericItem()];
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.Name = name;
    }
        
    public void Heal()
    {
        Health = 100;
    }

    public void ReceiveAttack(int attackValue)
    {
        Health = attackValue < 0 ? 0 : attackValue;
    }

    public void AddItem(IItem itemAdded)
    {
        this.Items.Add(itemAdded);
    }
}

public class GenericItem : IItem
{
    public bool IsMagical { get; set; }
        
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }

    public GenericItem(bool isMagical = true, int attackValue = 150, int defenseValue = 10)
    {
        this.IsMagical = isMagical;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
    }
}
public class WisardTest
{
    [Test]
    public void VerifyGettersAndSetters()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        Assert.That(wizard.Health, Is.EqualTo(100));
        Assert.That(wizard.Name, Is.EqualTo("Mago 1"));
        Assert.That(wizard.AttackValue, Is.EqualTo(50));
        Assert.That(wizard.DefenseValue, Is.EqualTo(100));
        Assert.That(wizard.Items.Count, Is.EqualTo(0));
        wizard.DefenseValue = 0;
        Assert.That(wizard.DefenseValue, Is.EqualTo(0));
        wizard.AttackValue = 0;
        Assert.That(wizard.AttackValue, Is.EqualTo(0));
        wizard.Health = 10;
        Assert.That(wizard.Health, Is.EqualTo(10));
        wizard.Name = "Mago 2";
        Assert.That(wizard.Name, Is.EqualTo("Mago 2"));
    }

    [Test]
    public void TryToAddGenericItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericItem item = new GenericItem();
        wizard.AddItem(item);
        Assert.That(wizard.Items.Count, Is.EqualTo(1));
        Assert.That(wizard.Items[0], Is.TypeOf<GenericItem>());
    }

    [Test]
    public void TryToAddDuplicateGenericItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericItem item = new GenericItem();
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        wizard.AddItem(item);
        wizard.AddItem(item);
        
        string console = sw.ToString();
        
        Assert.That(wizard.Items.Count, Is.EqualTo(1));
        Assert.That(wizard.Items[0], Is.TypeOf<GenericItem>());
        Assert.That(console, Contains.Substring("ya tiene un GenericItem"));
        
    }

    [Test]
    public void TryToAddAnotherGenericItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericItem item = new GenericItem();
        GenericItem item2 = new GenericItem();
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        wizard.AddItem(item);
        wizard.AddItem(item2);
        
        string console = sw.ToString();
        Assert.That(wizard.Items.Count, Is.EqualTo(1));
        Assert.That(wizard.Items[0], Is.TypeOf<GenericItem>());
        Assert.That(wizard.Items[0], Is.EqualTo(item2));
        Assert.That(console, Contains.Substring("WARNING: Ya existia un GenericItem"));
        Assert.That(wizard.Items.Contains(item), Is.False);
    }

    [Test]
    public void TryToAddNonMagicalItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericItem item = new GenericItem();
        item.IsMagical = false;
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        wizard.AddItem(item);
        string console = sw.ToString();
        Assert.That(wizard.Items.Count, Is.EqualTo(0));
        Assert.That(console, Contains.Substring("el item no es magico"));
    }
    [Test]
    public void GetTotalAttackWithoutItems()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        Assert.That(wizard.GetTotalAttack(), Is.EqualTo(50));
    }

    [Test]
    public void GetTotalAttackWithNormalItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericItem item = new GenericItem();
        wizard.AddItem(item);
        Assert.That(wizard.GetTotalAttack(), Is.EqualTo(200));
    }

    [Test]
    public void GetTotalAttackWithSpecialItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        Staff specialItem = new Staff(10, 10, true);
        wizard.AddItem(specialItem);
        Assert.That(wizard.GetTotalAttack(), Is.EqualTo(70));
    }

    [Test]
    public void GetTotalDefenseWithoutItems()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        Assert.That(wizard.GetTotalDefense(), Is.EqualTo(100));
    }

    [Test]
    public void GetTotalDefenseWithGenericItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericItem item = new GenericItem();
        wizard.AddItem(item);
        Assert.That(wizard.GetTotalDefense(), Is.EqualTo(110));
    }

    [Test]
    public void GetTotalDefenseWithSpecialItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        Staff specialItem = new Staff(10, 10, true);
        wizard.AddItem(specialItem);
        Assert.That(wizard.GetTotalDefense(), Is.EqualTo(120));
    }

    [Test]
    public void ReceiveAttackWithHigherDefense()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericCharacter genericCharacter = new GenericCharacter();
        wizard.ReceiveAttack(genericCharacter.AttackValue);
        Assert.That(wizard.Health, Is.EqualTo(100));
    }

    [Test]
    public void ReceiveAttackWithHigherPower()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericCharacter genericCharacter = new GenericCharacter();
        genericCharacter.AttackValue = 120;
        int expectedHealth = wizard.Health - (genericCharacter.AttackValue - wizard.DefenseValue);
        wizard.ReceiveAttack(genericCharacter.AttackValue);
        Assert.That(wizard.Health, Is.EqualTo(expectedHealth));
    }

    [Test]
    public void TryToHeal()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        wizard.Health = 20;
        wizard.Heal();
        Assert.That(wizard.Health, Is.EqualTo(100));
    }

    [Test]
    public void TryToRemoveExistingItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericItem item = new GenericItem();
        wizard.AddItem(item);
        wizard.RemoveItem(item);
        Assert.That(wizard.Items, Is.Empty);
    }
    [Test]
    public void TryToRemoveUnexistingItem()
    {
        Wizard wizard = new Wizard("Mago 1", 50, 100);
        GenericItem item = new GenericItem();
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        wizard.RemoveItem(item);
        string console = sw.ToString();
        
        Assert.That(console, Contains.Substring("ERROR: Mago 1 no tenia"));
    }
}