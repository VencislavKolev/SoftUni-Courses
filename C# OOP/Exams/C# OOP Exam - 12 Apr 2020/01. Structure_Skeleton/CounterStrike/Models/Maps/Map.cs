
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {

        }
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players
                .Where(x => x.GetType()
                .Name == "Terrorist");
            var counterRerrorists = players
                .Where(x => x.GetType()
                .Name == "CounterTerrorist");

            while (terrorists.Any(x => x.IsAlive) && counterRerrorists.Any(x => x.IsAlive))
            {
                foreach (var terrorist in terrorists
                      .Where(x => x.IsAlive))
                {
                    foreach (var ct in counterRerrorists
                         .Where(x => x.IsAlive))
                    {
                        if (terrorist.Gun.BulletsCount > 0)
                        {
                            int damagePoints = terrorist.Gun.Fire();
                            ct.TakeDamage(damagePoints);
                        }
                    }
                }
                foreach (var ct in counterRerrorists
                    .Where(x => x.IsAlive))
                {
                    foreach (var terrorist in terrorists
                         .Where(x => x.IsAlive))
                    {
                        if (ct.Gun.BulletsCount > 0)
                        {
                            int dmgPoints = ct.Gun.Fire();
                            terrorist.TakeDamage(dmgPoints);
                        }
                    }
                }
            }
            if (terrorists.Any(x => x.IsAlive))
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }
        }
    }
}
