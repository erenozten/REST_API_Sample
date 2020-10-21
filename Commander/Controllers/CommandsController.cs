using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers{
    // [Route("api/[commands]")] // Bu şekilde de yazılabilir. 
    // Böylece route her zaman sabit kalır. Mantıklı. 
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        private readonly MockCommanderRepo _repository = new MockCommanderRepo(); 

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands(){
        var commandItems = _repository.GetAllCommands();

        // return'e dikkat: 
        // return Ok yazıp içine commandItems listemizi verdik.
        // -> Bu metodumuz Ienumerable<Command> return ediyordu.
        // biz de buna uyarak commandItems'ı return ettik:
        return Ok(commandItems);
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            // Peki bu end point'in içine  
            // id nereden geliyor? Request'ten geliyor.
            // URI'dan geliyor.
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        }        
    }
}  