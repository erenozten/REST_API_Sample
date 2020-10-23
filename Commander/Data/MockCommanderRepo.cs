
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data{
    public class MockCommanderRepo : ICommanderRepo{

        List<Command> commands = new List<Command>(){
            new Command(){Id=1, HowTo="HowTo1", Line="Line1", Platform="Platform1"},
            new Command(){Id=2, HowTo="HowTo2", Line="Line2", Platform="Platform2"},
            new Command(){Id=3, HowTo="HowTo3", Line="Line3", Platform="Platform3"},
            new Command(){Id=4, HowTo="HowTo4", Line="Line4", Platform="Platform4"}
        };

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return commands;
        }

        public Command GetCommandById(int id)
        {
            var command = commands.Find(n=>n.Id == id);
            return command;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}