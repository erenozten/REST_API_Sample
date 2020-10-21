
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data{
    public class MockCommanderRepo : ICommanderRepo{
        public IEnumerable<Command> GetAllCommands(){
        
        var commands = new List<Command>(){
            new Command(){Id=0, HowTo="HowTo1", Line="Line1", Platform="Platform1"},
            new Command(){Id=1, HowTo="HowTo2", Line="Line2", Platform="Platform2"},
            new Command(){Id=2, HowTo="HowTo3", Line="Line3", Platform="Platform3"},
            new Command(){Id=0, HowTo="HowTo4", Line="Line4", Platform="Platform4"}
        };
            return commands;
        }
        public Command GetCommandById(int id){
            return new Command(){Id=id, HowTo="", Line="q", Platform="we"};
        }
    }
}