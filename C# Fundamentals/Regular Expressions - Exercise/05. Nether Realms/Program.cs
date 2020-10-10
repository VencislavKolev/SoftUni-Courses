using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Nether_Realms
{
    public class Deamon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] deamons = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            SortedDictionary<string, Deamon> deamonData = new SortedDictionary<string, Deamon>();

            foreach (var deamon in deamons)
            {
                var healthSymbols = deamon
                    .Where(s => !char.IsDigit(s) &&
                    s != '+' &&
                    s != '-' &&
                    s != '*' &&
                    s != '/' &&
                    s != '.');

                int health = 0;

                foreach (var healthSymbol in healthSymbols)
                {
                    health += healthSymbol;
                }

                Regex regex = new Regex(@"-?\d+\.?\d*");

                MatchCollection matches = regex.Matches(deamon);

                double damage = 0.0;

                foreach (Match match in matches)
                {
                    double currentNumber = double.Parse(match.Value);
                    damage += currentNumber;
                }

                char[] modifiers = deamon
                    .Where(s => s == '*' || s == '/').ToArray();

                foreach (var modifier in modifiers)
                {
                    if (modifier == '*')
                    {
                        damage *= 2;
                    }
                    else if (modifier == '/')
                    {
                        damage /= 2;
                    }
                }
                deamonData.Add(deamon, new Deamon
                {
                    Name = deamon,
                    Health = health,
                    Damage = damage
                });
            }

            foreach (var demonEntry in deamonData)
            {
                Deamon demon = demonEntry.Value;

                Console.WriteLine("{0} - {1} health, {2:F2} damage", demon.Name, demon.Health, demon.Damage);
            }
        }
    }
}
