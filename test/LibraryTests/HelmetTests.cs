using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace TestLibrary;

public class HelmetTests
{
    public Helmet Casco;
    
    [SetUp]
    public void Setup()
    {
        Casco = new Helmet(true, 0, 20);
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.That(Casco.IsMagical,Is.EqualTo(true));
        Assert.That(Casco.AttackValue,Is.EqualTo(0));
        Assert.That(Casco.DefenseValue,Is.EqualTo(20) );
    }
}