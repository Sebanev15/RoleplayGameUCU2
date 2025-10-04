using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;

public class SwordTest
{
    private Sword sword;

    [SetUp]
    public void Setup()
    {
        sword = new Sword(10, 10, true);
    }

    [Test]
    public void TestSword()
    {
        Assert.That(sword.AttackValue, Is.EqualTo(10));
        Assert.That(sword.DefenseValue, Is.EqualTo(10));
        Assert.That(sword.IsMagical, Is.True);
    }
}