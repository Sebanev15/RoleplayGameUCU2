using Library.Characters;
using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

[TestFixture]
public class DwarfTest
{
     private Dwarf dormilon;
     private Axe axe;
    [SetUp]
    public void Setup()
    {
         dormilon = new Dwarf("dormilon", 100, 200, 200);
         axe = new Axe(50, 5, false);

    }

    [Test]
    public void ConstructorTestValidValuesDwarf()
    {
        Assert.That(dormilon.Name, Is.EqualTo("dormilon"));
        Assert.That(dormilon.AttackValue, Is.EqualTo(100));
        Assert.That(dormilon.DefenseValue, Is.EqualTo(200));
        Assert.That(dormilon.Health, Is.EqualTo(200));
        Assert.That(dormilon.Items.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void ReceiveAttackBelowZeroAndNegative()
    {
        dormilon.ReceiveAttack(210);
        Assert.That(dormilon.Health, Is.EqualTo(190));
        dormilon.ReceiveAttack(200+200);
        Assert.That(dormilon.Health, Is.EqualTo(0));
        dormilon.ReceiveAttack(-100);
        Assert.That(dormilon.Health, Is.EqualTo(0));

    }
    
    [Test]
    public void HealValues()
    { 
        dormilon.Health -= 100;
        dormilon.Heal();
        Assert.That(dormilon.Health, Is.EqualTo(200));
    }
    
    [Test]
    public void GetTotalAttackAfterAddAndRemoveItem()
    {
        
        Assert.That(dormilon.GetTotalAttack(), Is.EqualTo(100));
        dormilon.AddItem(axe);
        Assert.That(dormilon.GetTotalAttack(), Is.EqualTo(200));
        dormilon.RemoveItem(axe);
        Assert.That(dormilon.GetTotalAttack(), Is.EqualTo(100));

    }
    [Test]
    public void GetTotalDefenseAfterAddAndRemoveItem()
    {
        
        Assert.That(dormilon.GetTotalDefense(), Is.EqualTo(200));
        dormilon.AddItem(axe);
        Assert.That(dormilon.GetTotalDefense(), Is.EqualTo(210));
        dormilon.RemoveItem(axe);
        Assert.That(dormilon.GetTotalDefense(), Is.EqualTo(200));

    }
    
    [Test]
    public void AddItemDuplicatedVerify()
    {
        dormilon.AddItem(axe);
        Assert.That(dormilon.Items.Count, Is.EqualTo(1));
        dormilon.AddItem(axe);
        Assert.That(dormilon.Items.Count, Is.EqualTo(1));

    }
    [Test]
    public void RemoveItemDuplicatedVerify()
    {
        dormilon.AddItem(axe);
        Assert.That(dormilon.Items.Count, Is.EqualTo(1));
        dormilon.RemoveItem(axe);
        Assert.That(dormilon.Items.Count, Is.EqualTo(0));
        dormilon.RemoveItem(axe);
        Assert.That(dormilon.Items.Count, Is.EqualTo(0));

    }
    

    
    
    
}