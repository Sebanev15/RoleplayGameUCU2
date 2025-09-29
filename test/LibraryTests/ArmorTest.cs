using Library.Items;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class ArmorTest
{
    private Armor pechera;
    
    [SetUp]
    public void Setup()
    {
        pechera = new Armor(0, 100, false);
       

    }

    [Test]
    public void ConstructorTestValidValuesArmor()
    {
        Assert.That(pechera.AttackValue, Is.EqualTo(0));
        Assert.That(pechera.DefenseValue, Is.EqualTo(100));
        Assert.That(pechera.IsMagical, Is.EqualTo(false));
    }
}