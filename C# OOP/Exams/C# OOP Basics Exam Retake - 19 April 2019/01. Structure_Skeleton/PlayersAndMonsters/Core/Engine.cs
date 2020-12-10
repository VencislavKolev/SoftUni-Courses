
using System;
using PlayersAndMonsters.IO.Contracts;
using PlayersAndMonsters.Core.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = new ManagerController();
        }
        public void Run()
        {
            string command = this.reader.ReadLine();

            while (command != "Exit")
            {
                try
                {
                    string[] args = command.Split();
                    string cmdType = args[0];
                    string resultMessage = string.Empty;

                    if (cmdType == "AddPlayer")
                    {
                        resultMessage = this.managerController.AddPlayer(args[1], args[2]);
                    }
                    else if (cmdType == "AddCard")
                    {
                        resultMessage = this.managerController.AddCard(args[1], args[2]);
                    }
                    else if (cmdType == "AddPlayerCard")
                    {
                        resultMessage = this.managerController.AddPlayerCard(args[1], args[2]);
                    }
                    else if (cmdType == "Fight")
                    {
                        resultMessage = this.managerController.Fight(args[1], args[2]);
                    }
                    else if (cmdType == "Report")
                    {
                        resultMessage = this.managerController.Report();
                    }

                    this.writer.WriteLine(resultMessage);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }

                command = this.reader.ReadLine();
            }
        }
    }
}
