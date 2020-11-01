
using P07.MilitaryElite.Contracts;
using P07.MilitaryElite.Enumerations;
using P07.MilitaryElite.Exceptions;
using System;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }
        private Corps TryParseCorps(string corps)
        {
            Corps corp;
            bool parsed = Enum.TryParse<Corps>(corps, out corp);
            if (!parsed)
            {
                throw new InvalidCorpsException();
            }
            return corp;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps.ToString()}");
            return sb.ToString().TrimEnd();
        }
    }
}
