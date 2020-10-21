using System.Collections.Generic;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers{
    
    // [Route("api/[commands]")] // Bu şekilde de yazılabilir. 
    // Böylece route her zaman sabit kalır. Mantıklı. 
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
              
    }
}  