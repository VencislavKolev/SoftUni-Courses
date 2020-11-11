using System;
using System.Linq;
using System.Text;

using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository gunRepository;
        private PlayerRepository playerRepository;
        private IMap map;
        public Controller()
        {
            this.gunRepository = new GunRepository(
                );
            this.playerRepository = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            this.gunRepository.Add(gun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.gunRepository.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            IPlayer player = null;
            if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.playerRepository.Add(player);
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IPlayer player in this.playerRepository.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var alivePlayers = this.playerRepository
                .Models
                .Where(x => x.IsAlive)
                .ToList();
            string result = this.map.Start(alivePlayers);
            return result;
        }
    }
}
