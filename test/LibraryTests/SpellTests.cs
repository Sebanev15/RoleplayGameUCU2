using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace TestLibrary;

public class SpellTests
{
    public Spell Hechizo;
    
    [SetUp]
    public void Setup()
    {
        Hechizo = new Spell(10, 20);
    }

    [Test]
    public void IsMagicalTest()
    {
        Assert.That(Hechizo.IsMagical,Is.EqualTo(true));
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.That(Hechizo.AttackValue,Is.EqualTo(10));
        Assert.That(Hechizo.DefenseValue,Is.EqualTo(20));
    }

}