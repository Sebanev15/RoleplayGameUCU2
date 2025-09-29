using Library.Characters;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class DwarfTest
{
     private Dwarf dormilon;
    [SetUp]
    public void Setup()
    {
         dormilon = new Dwarf("dormilon", 100, 200, 200);


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
    public void ReceiveAttack()
    {
        Assert.That(dormilon.Name, Is.EqualTo("dormilon"));
        Assert.That(dormilon.AttackValue, Is.EqualTo(100));
        Assert.That(dormilon.DefenseValue, Is.EqualTo(200));
        Assert.That(dormilon.Health, Is.EqualTo(200));
        Assert.That(dormilon.Items.Count, Is.EqualTo(0));
    }
    
    
    
    
    
}