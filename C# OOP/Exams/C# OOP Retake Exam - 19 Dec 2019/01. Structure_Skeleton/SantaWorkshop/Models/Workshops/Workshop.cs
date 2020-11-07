﻿
using System.Globalization;
using System.Linq;

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy > 0 && dwarf.Instruments.Any())
            {
                IInstrument instrument = dwarf.Instruments.First();

                while (!present.IsDone() && dwarf.Energy > 0 && !instrument.IsBroken())
                {
                    dwarf.Work();
                    instrument.Use();
                    present.GetCrafted();
                }
                if (present.IsDone())
                {
                    break;
                }
                if (instrument.IsBroken())
                {
                    dwarf.Instruments.Remove(instrument);
                }

            }
        }
    }
}
