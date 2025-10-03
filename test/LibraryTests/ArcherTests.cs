using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace TestLibrary;

public class ArcherTests
{
    public Archer Archer1;
    public Bow Arco;
    public Helmet Casco;
    
    [SetUp]
    public void Setup()
    {
        Archer1 = new Archer("Legolas", 30, 40);
        Arco = new Bow(20, 5, false);
        Casco = new Helmet(false, 0, 20);
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.That(Archer1.Name,Is.EqualTo("Legolas"));
        Assert.That(Archer1.AttackValue,Is.EqualTo(30));
        Assert.That(Archer1.DefenseValue,Is.EqualTo(40) );
    }
    
    [Test]
    public void RecieveAttackTest()
    {
        Archer1.ReceiveAttack(50);
        Assert.That(Archer1.Health, Is.EqualTo(90));
    }
    
    [Test]
    public void GetTotalAttackTest()
    {
        Archer1.AddItem(Arco);
        Archer1.AddItem(Casco);
        Assert.That(Archer1.GetTotalAttack(), Is.EqualTo(30+20*2));
    }
    
    [Test]
    public void GetTotalDefenseTest()
    {
        Archer1.AddItem(Arco);
        Archer1.AddItem(Casco);
        Assert.That(Archer1.GetTotalDefense(), Is.EqualTo(40+5*2+20));
    }
    
    [Test]
    public void HealTest()
    {
        Archer1.ReceiveAttack(90);
        Archer1.Heal();
        Assert.That(Archer1.Health, Is.EqualTo(100));
    }
    
    [Test]
    public void AddItemTest()
    {
        Bow Arco2 = new Bow(12, 2, false); 
        Assert.That(Archer1.Items.Count, Is.EqualTo(0));
        Archer1.AddItem(Arco);
        Assert.That(Archer1.Items.Count, Is.EqualTo(1));
        Archer1.AddItem(Arco);
        Assert.That(Archer1.Items.Count, Is.EqualTo(1));
        Archer1.AddItem(Arco2);
        Assert.That(Archer1.Items.Count, Is.EqualTo(1));
        Archer1.AddItem(Casco);
        Assert.That(Archer1.Items.Count, Is.EqualTo(2));
    }

    [Test]
    public void RemoveItemTest()
    {
        Assert.That(Archer1.Items.Count, Is.EqualTo(0));
        Archer1.AddItem(Arco);
        Archer1.RemoveItem(Casco);
        Assert.That(Archer1.Items.Count, Is.EqualTo(1));
        Archer1.RemoveItem(Arco);
        Assert.That(Archer1.Items.Count, Is.EqualTo(0));
    }
    
}