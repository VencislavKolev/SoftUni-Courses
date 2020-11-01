
using P07.MilitaryElite.Contracts;
using P07.MilitaryElite.Core.Contracts;
using P07.MilitaryElite.Enumerations;
using P07.MilitaryElite.Exceptions;
using P07.MilitaryElite.IO.Contracts;
using P07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P07.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                ISoldier soldier = null;
                string[] cmdArgs = command.Split();
                string type = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];
                if (type == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    soldier = AddGeneral(cmdArgs, id, firstName, lastName);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        IEngineer engineer = CreateEngineer(cmdArgs, id, firstName, lastName, salary, corps);
                        soldier = engineer;
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }

                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        ICommando commando = GetCommando(cmdArgs, id, firstName, lastName, salary, corps);
                        soldier = commando;
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }

                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }
            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static ICommando GetCommando(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
            string[] missionArgs = cmdArgs.Skip(6).ToArray();
            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    string codeName = missionArgs[i];
                    string state = missionArgs[i + 1];
                    IMission mission = new Mission(codeName, state);
                    commando.AddMission(mission);
                }
                catch (InvalidStateException ise)
                {
                    continue;
                }

            }

            return commando;
        }

        private static IEngineer CreateEngineer(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            string[] repairArgs = cmdArgs.Skip(6).ToArray();
            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hourWorked = int.Parse(repairArgs[i + 1]);
                IRepair repair = new Repair(partName, hourWorked);
                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private ISoldier AddGeneral(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            int[] ids = cmdArgs.Skip(5).Select(int.Parse).ToArray(); // possible error
            foreach (var pid in ids)
            {
                ISoldier privateToAdd = this.soldiers
                    .First(x => x.Id == pid);
                general.AddPrivate(privateToAdd);
            }
            soldier = general;
            return soldier;
        }
    }
}
