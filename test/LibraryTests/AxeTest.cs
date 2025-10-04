using Library.Items;
using Ucu.Poo.RoleplayGame;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class AxeTest
{
    private Axe axel;
    
    [SetUp]
    public void Setup()
    {
        axel = new Axe(100, 20, false);
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.That(axel.AttackValue, Is.EqualTo100);
        Assert.That(axel.DefenseValue, Is.EqualTo(20));
        Assert.That(axel.IsMagical, Is.EqualTo(false));
    }
}