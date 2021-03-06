using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = _context.Commands;
            return commands;
        }

        public Command GetCommandById(int id)
        {
            var command = _context.Commands.FirstOrDefault(n=>n.Id == id);
            return command;
        }
        public void CreateCommand(Command command)
        {
            if(command == null)
            {
               throw new ArgumentNullException(nameof(command));
            }
            _context.Add(command);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}