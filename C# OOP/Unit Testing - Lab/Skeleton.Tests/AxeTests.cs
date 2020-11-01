using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;
    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(2, 2);
        this.dummy = new Dummy(20, 20);
    }
    [Test]
    public void TestIfWeaponLosesDurabilityAfterAttack()
    {
        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(1),
            "Axe Durability doesn't change after attack");
    }
    [Test]
    public void TestAttackWithBrokenWeapon()
    {
        //Act
        axe.Attack(dummy);
        axe.Attack(dummy);

        //Assert
        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}