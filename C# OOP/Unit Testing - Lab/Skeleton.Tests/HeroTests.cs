using Moq;
using NUnit.Framework;
using Skeleton.Contracts; //Comment this using because it will NOT pass in JUDJE!!!

[TestFixture]
public class HeroTests
{
    private IWeapon weapon;
    private const int Attack = 10;
    private const int Durability = 10;

    private ITarget target;
    private const int Health = 5;
    private const int Experience = 10;

    private Hero hero;
    private const string HeroName = "Venci";

    [SetUp]
    public void TestInitialize()
    {
        this.weapon = new Axe(Attack, Durability);
        this.target = new Dummy(Health, Experience);
        this.hero = new Hero(HeroName, this.weapon);
    }
    [Test]
    public void TestIfHeroGainsExperienceWhenTargetDies()
    {
        //Act
        hero.Attack(target);

        //Assert
        // Assert.That(hero.Experience, Is.EqualTo(10),"Hero doesn't gain the correct amount of experience.");

        Assert.AreEqual(this.target.GiveExperience(), hero.Experience, "Hero doesn't gain the correct amount of experience.");

    }
    [Test]
    public void TestIfHeroGainsExperienceWhenTargetDiesWithMoq()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget
            .Setup(p => p.Health)
            .Returns(0);
        fakeTarget
            .Setup(p => p.GiveExperience())
            .Returns(20);
        fakeTarget
            .Setup(p => p.IsDead())
            .Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero(HeroName, fakeWeapon.Object);

        //Act
        hero.Attack(fakeTarget.Object);

        //Assert
        Assert.That(hero.Experience, Is.EqualTo(20));
    }
}