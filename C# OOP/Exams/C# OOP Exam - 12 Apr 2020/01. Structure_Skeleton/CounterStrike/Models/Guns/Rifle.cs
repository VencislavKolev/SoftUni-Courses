
namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int RIFLE_FIRE_BULLETS = 10;
        public Rifle(string name, int bullets)
            : base(name, bullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount >= 10)
            {
                this.BulletsCount -= RIFLE_FIRE_BULLETS;
                return RIFLE_FIRE_BULLETS;
            }
            return 0;
        }
    }
}
