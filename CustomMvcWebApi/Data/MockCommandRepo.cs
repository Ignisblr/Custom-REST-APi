using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomMvcWebApi.Models;
using CustomMvcWebApi.Models.Abstract;

namespace CustomMvcWebApi.Data
{
    /// <summary>
    /// Additional class, which helps to test api`s model
    /// </summary>
    public class MockCommandRepo : ICommanderRepo
    {
        static List<Command> commands;
        public ICommand GetCommandById(int id)
        {
            //if (id != 0) return new Command
            //{
            //    Id = id,
            //    Line = $"line #{id}",
            //    HowTo = "some text",
            //    Platform = "some some"
            //};


            if (id != 0) return commands[id];

            else return new Command
            {
                Id = 0,
                Line = "line",
                HowTo = "some text",
                Platform = "some platform"
            };
        }

        public IEnumerable<ICommand> GetCommands()
        {
            if (commands == null)
            {
                commands = new List<Command>
            {
                new Command { Id = 0, Line = "second line", HowTo = "use some feature", Platform = "basic definition"},
                new Command { Id = 1, Line = "third line", HowTo = "use some signature", Platform = "basic word" },
                new Command { Id = 2, Line = "next line", HowTo = "use my sox", Platform = "purple sox" }
            };
            }

            else return commands;
            

            return commands;
        }

        public void AddCommand(Command command)
        {
            commands.Add(command);
        }
    }
}
