using Ucu.Poo.RoleplayGame;
using NUnit.Framework;
namespace LibraryTests;

public class StaffTest
{
    private Staff staff;

    [SetUp]
    public void Setup()
    {
        staff = new Staff(10, 10, true);
    }

    [Test]
    public void VerifyConstructor()
    {
        Assert.That(staff.DefenseValue, Is.EqualTo(10));
        Assert.That(staff.IsMagical, Is.True);
        Assert.That(staff.AttackValue, Is.EqualTo(10));
        
    }
    
}