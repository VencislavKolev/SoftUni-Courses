namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;
    using System.Net;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IManagerController managerController = new ManagerController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(managerController, reader, writer);
            engine.Run();
        }
    }
}