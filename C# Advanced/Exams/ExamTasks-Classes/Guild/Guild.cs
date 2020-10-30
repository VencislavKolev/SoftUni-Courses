using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            players = new List<Player>();
        }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public int Count
        {
            get { return this.players.Count; }
        }
        public void AddPlayer(Player player)
        {
            if (this.players.Count < this.Capacity)
            {
                this.players.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = GetPlayer(name);
            if (player != null)
            {
                this.players.Remove(player);
                return true;
            }
            return false;
        }

        private Player GetPlayer(string name)
        {
            return this.players
                            .FirstOrDefault(x => x.Name == name);
        }

        public void PromotePlayer(string name)
        {
            Player player = GetPlayer(name);
            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = GetPlayer(name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string className)
        {
            Player[] kicked= this.players
                .Where(x => x.Class == className)
                .ToArray();
            this.players.RemoveAll(x => x.Class == className);
            return kicked;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}")
                .AppendLine(string.Join(Environment.NewLine, this.players));
            return sb.ToString().TrimEnd();
        }
    }
}
