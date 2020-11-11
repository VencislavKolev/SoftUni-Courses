
namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int PISTOL_FIRE_BULLETS = 1;
        public Pistol(string name, int bullets)
            : base(name, bullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount > 0)
            {
                this.BulletsCount -= PISTOL_FIRE_BULLETS;
                return PISTOL_FIRE_BULLETS;
            }
            return 0;
        }
    }
}
