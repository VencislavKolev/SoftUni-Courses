using System;
using System.Collections.Generic;

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private const int DEF_DWARF_WORK = 10;

        private string name;
        private int energy;

        private Dwarf()
        {
            this.Instruments = new List<IInstrument>();
        }
        protected Dwarf(string name, int energy)
            :this()
        {
            this.Name = name;
            this.Energy = energy;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            protected set
            {
                this.energy = value > 0 ? value : 0;
                //if (value < 0)
                //{
                //    this.energy = 0;
                //}
                //this.energy = value;
            }
        }
        protected virtual int DwarfWork => DEF_DWARF_WORK;
        public ICollection<IInstrument> Instruments { get; }

        public void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }

        public abstract void Work();
    }
}
