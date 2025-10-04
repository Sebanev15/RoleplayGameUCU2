using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;

public class ShieldTest
{
    private Shield shield;

    [SetUp]
    public void Setup()
    {
        shield = new Shield(10, 10, true);
    }

    [Test]
    public void TestShield()
    {
        Assert.That(shield.DefenseValue, Is.EqualTo(10));
        Assert.That(shield.AttackValue, Is.EqualTo(10));
        Assert.That(shield.IsMagical, Is.True);
    }
}