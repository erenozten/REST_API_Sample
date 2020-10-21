using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data{
    public interface ICommanderRepo{
        // Tüm command'leri dönder.
        IEnumerable<Command> GetAllCommands();

        // Id'ye göre command objesi dönder.
        Command GetCommandById(int id);
    }
}