using Library.Items;
using Ucu.Poo.RoleplayGame;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class BowTest
{
    private Bow recurvado;
    
    [SetUp]
    public void Setup()
    {
        recurvado = new Bow(100,20,false);
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.That(recurvado.AttackValue, Is.EqualTo(100));
        Assert.That(recurvado.DefenseValue, Is.EqualTo(20));
        Assert.That(recurvado.IsMagical, Is.EqualTo(false));
    }
}