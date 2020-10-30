
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
        private Guild()
        {
            this.players = new List<Player>();
        }
        public Guild(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.players.Count;

        public void AddPlayer(Player player)
        {
            if (this.players.Count < this.Capacity)
            {
                this.players.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = this.players
                .FirstOrDefault(x => x.Name == name);
            return this.players.Remove(player);
        }
        public void PromotePlayer(string name)
        {
            Player player = this.players
                .FirstOrDefault(x => x.Name == name);
            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = this.players
                .FirstOrDefault(x => x.Name == name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string classInput)
        {
            
            List<Player> removed= this.players
                .Where(x => x.Class == classInput)
                .ToList();

            this.players.RemoveAll(x => x.Class == classInput);

            return removed.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in this.players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
