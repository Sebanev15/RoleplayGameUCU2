using Library.Characters;
using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

[TestFixture]
public class KnightTest
{
     private Knight megacaballero;
     private Sword sword;
     private Shield shield;
    [SetUp]
    public void Setup()
    {
         megacaballero = new Knight("megacaballero", 100, 100);
         sword = new Sword(50,50, false);
         shield = new Shield(50, 50, false);

    }

    [Test]
    public void ConstructorTest()
    {
        Assert.That(megacaballero.Name, Is.EqualTo("megacaballero"));
        Assert.That(megacaballero.AttackValue, Is.EqualTo(100));
        Assert.That(megacaballero.DefenseValue, Is.EqualTo(100));
        Assert.That(megacaballero.Health, Is.EqualTo(100));
        Assert.That(megacaballero.Items.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void ReceiveAttackTest()
    {
        megacaballero.ReceiveAttack(110);
        Assert.That(megacaballero.Health, Is.EqualTo(90));
        megacaballero.Heal();
        megacaballero.ReceiveAttack(100+100);
        Assert.That(megacaballero.Health, Is.EqualTo(0));
        megacaballero.Heal();
        megacaballero.ReceiveAttack(-100);
        Assert.That(megacaballero.Health, Is.EqualTo(100));
        megacaballero.Heal();
        megacaballero.ReceiveAttack(100);
        Assert.That(megacaballero.Health, Is.EqualTo(100));
    }
    
    [Test]
    public void HealTest()
    { 
        megacaballero.Health -= 100;
        megacaballero.Heal();
        Assert.That(megacaballero.Health, Is.EqualTo(100));
    }
    
    [Test]
    public void GetTotalAttackAfterAddAndRemoveItem()
    {
        Bow bow = new Bow(50, 0, false);
        Assert.That(megacaballero.GetTotalAttack(), Is.EqualTo(100));
        megacaballero.AddItem(sword);
        Assert.That(megacaballero.GetTotalAttack(), Is.EqualTo(200));
        megacaballero.AddItem(shield);
        Assert.That(megacaballero.GetTotalAttack(), Is.EqualTo(300));
        megacaballero.AddItem(bow);
        Assert.That(megacaballero.GetTotalAttack(), Is.EqualTo(350));
        
        megacaballero.RemoveItem(sword);
        megacaballero.RemoveItem(shield);
        Assert.That(megacaballero.GetTotalAttack(), Is.EqualTo(150));
    }
    [Test]
    public void GetTotalDefenseAfterAddAndRemoveItem()
    {
        Bow bow = new Bow(0, 100, false);
        Assert.That(megacaballero.GetTotalDefense(), Is.EqualTo(100));
        megacaballero.AddItem(shield);
        Assert.That(megacaballero.GetTotalDefense(), Is.EqualTo(200));
        megacaballero.RemoveItem(shield);
        Assert.That(megacaballero.GetTotalDefense(), Is.EqualTo(100));
        megacaballero.AddItem(sword);
        Assert.That(megacaballero.GetTotalDefense(), Is.EqualTo(200));
        megacaballero.RemoveItem(sword);
        Assert.That(megacaballero.GetTotalDefense(), Is.EqualTo(100));
        megacaballero.AddItem(bow);
        Assert.That(megacaballero.GetTotalDefense(), Is.EqualTo(200));
    }
    
    [Test]
    public void NoDuplicateItemsTest()
    {
        Sword sword2= new Sword(100, 100, false);
        megacaballero.AddItem(sword);
        Assert.That(megacaballero.Items.Count, Is.EqualTo(1));
        megacaballero.AddItem(sword);
        Assert.That(megacaballero.Items.Count, Is.EqualTo(1));
        megacaballero.AddItem(sword2);
        Assert.That(megacaballero.Items.Count, Is.EqualTo(1));
        Assert.That(megacaballero.Items[0]==sword2, Is.True);
        
    }
}