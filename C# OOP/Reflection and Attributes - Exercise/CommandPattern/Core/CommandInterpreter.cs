
using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string POSTFIX = "Command";
        public CommandInterpreter()
        {

        }
        public string Read(string args)
        {
            string[] cmdTokens = args.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            //Hello + Command = HelloCommand -> VALID
            string cmdName = cmdTokens[0] + POSTFIX;
            string[] cmdArgs = cmdTokens
                                        .Skip(1)
                                        .ToArray();
            //Get assembly in order to get types
            Assembly assembly = Assembly.GetCallingAssembly();

            //Get concrete command type in order to produce instance of concrete type
            //ToLower() in order to be case insensitive!
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == cmdName.ToLower());
            if (commandType == null)
            {
                throw new ArgumentException("Invalid type!");
            }

            //Second way of achieving the result via constructor
            //ConstructorInfo constructor = commandType
            //    .GetConstructors()
            //    .FirstOrDefault(c => c.GetParameters().Length == 0);
            //object[] ctorArgs = new object[] { };
            //ICommand commandInstance = (ICommand)constructor.Invoke(ctorArgs);

            //Create instance ofconcrete command in order to invoke Execute()
            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(cmdArgs);
            return result;
        }
    }
}
