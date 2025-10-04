using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace TestLibrary;

public class SpellsBookTests
{
    public SpellsBook Libro;
    public Spell Hechizo; 

    [SetUp]
    public void Setup()
    {
        Libro = new SpellsBook();
        Hechizo = new Spell(10, 20);
    }

    [Test]
    public void AttackValueTest()
    {
        Assert.That(Libro.AttackValue, Is.EqualTo(0));
        Libro.AddSpell(Hechizo);
        Assert.That(Libro.AttackValue, Is.EqualTo(10));
    }

    [Test]
    public void IsMagicalTest()
    {
        Assert.That(Libro.IsMagical,Is.EqualTo(true));
    }

    [Test]
    public void DefenseValueTest()
    {
        Assert.That(Libro.DefenseValue, Is.EqualTo(0));
        Libro.AddSpell(Hechizo);
        Assert.That(Libro.DefenseValue, Is.EqualTo(20));
    }
    
    [Test]
    public void AddSpellTest()
    {
        Assert.That(Libro.Spells.Count,Is.EqualTo(0));
        Libro.AddSpell(Hechizo);
        Assert.That(Libro.Spells.Count,Is.EqualTo(1));
        Libro.AddSpell(Hechizo);
        Assert.That(Libro.Spells.Count,Is.EqualTo(1));
    }

    [Test]
    public void RemoveSpellTest()
    {
        Assert.That(Libro.Spells.Count,Is.EqualTo(0));
        Libro.RemoveSpell(Hechizo);
        Assert.That(Libro.Spells.Count,Is.EqualTo(0));
        Libro.AddSpell(Hechizo);
        Assert.That(Libro.Spells.Count,Is.EqualTo(1));
        Libro.RemoveSpell(Hechizo);
        Assert.That(Libro.Spells.Count,Is.EqualTo(0));
    }
}