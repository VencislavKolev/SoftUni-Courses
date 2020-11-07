
using System;
using System.Text;
using System.Linq;

using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfRepository;
        private PresentRepository presentRepository;

        public Controller()
        {
            this.dwarfRepository = new DwarfRepository();
            this.presentRepository = new PresentRepository();
        }
        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfRepository.Add(dwarf);
            string output = String.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
            return output;
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfRepository.FindByName(dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }
            IInstrument instrument = new Instrument(power);
            dwarf.AddInstrument(instrument);

            string output = String.Format(OutputMessages.InstrumentAdded, power, dwarfName);
            return output;
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            this.presentRepository.Add(present);

            string output = String.Format(OutputMessages.PresentAdded, presentName);
            return output;
        }

        public string CraftPresent(string presentName)
        {

            Workshop workshop = new Workshop();
            IPresent present = this.presentRepository.FindByName(presentName);
            var dwarfsReadyToWork = this.dwarfRepository
                .Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();

            if (!dwarfsReadyToWork.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            foreach (IDwarf dwarf in dwarfsReadyToWork)
            {
                workshop.Craft(present, dwarf);
                if (dwarf.Energy <= 0)
                {
                    this.dwarfRepository.Remove(dwarf);
                }
                if (present.IsDone())
                {
                    break;
                }
            }

            string output = string.Format(present.IsDone() ?
                OutputMessages.PresentIsDone :
                OutputMessages.PresentIsNotDone, presentName);
            return output;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int craftedPresents = presentRepository
                            .Models
                            .Count(x => x.IsDone());

            sb.AppendLine($"{craftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");
            foreach (IDwarf dwarf in dwarfRepository.Models)
            {
                int notBrokenInstruments = dwarf.Instruments
                             .Count(x => x.Power > 0);

                sb.AppendLine($"Name: {dwarf.Name}")
                  .AppendLine($"Energy: {dwarf.Energy}")
                  .AppendLine($"Instruments: {notBrokenInstruments} not broken left");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
