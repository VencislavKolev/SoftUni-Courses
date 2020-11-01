using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy aliveDummy;
    private Dummy deadDummy;

    private const int attackPoints = 10;
    [SetUp]
    public void TestInit()
    {
        this.aliveDummy = new Dummy(15, 10);
        this.deadDummy = new Dummy(0, 20);
    }
    [Test]
    public void TestDummyLosesHealthIfAttacked()
    {
        //Act
        aliveDummy.TakeAttack(attackPoints);
        int expected = 5;
        //Assert
        Assert.That(aliveDummy.Health, Is.EqualTo(expected));

        ////Arrange
        //var dummy = new Dummy(25, 50);
        ////Act
        //dummy.TakeAttack(5);
        ////Assert
        //Assert.That(dummy.Health, Is.EqualTo(20));
    }
    [Test]
    public void TestDeadDummyThrowsExceptionIfAttacked()
    {
        //Assert
        Assert.That(() => deadDummy.TakeAttack(attackPoints),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));

        ////Arrange
        //var dummy = new Dummy(0, 50);

        ////Assert            //Act
        //Assert.That(() => dummy.TakeAttack(10),
        //    Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }
    [Test]
    public void TestDeadDummyCanGiveExperience()
    {
        int dummyXP = 20;
        //Assert
        Assert.That(deadDummy.GiveExperience(), Is.EqualTo(dummyXP));

        ////Arragne
        //var dummy = new Dummy(0, 50);
        ////Act
        //dummy.GiveExperience();
        ////Assert
        //Assert.That(() => dummy.GiveExperience(), Is.EqualTo(50));
    }
    [Test]
    public void TestAliveDummyCannotGiveExperience()
    {
        //Assert
        Assert.That(() => aliveDummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));

        ////Arrange
        //var dummy = new Dummy(10, 50);
        ////Assert
        //Assert.That(() => dummy.GiveExperience(),
        //    Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
