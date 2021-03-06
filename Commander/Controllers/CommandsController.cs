using System;
using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers{
    // [Route("api/[commands]")] // Bu şekilde de yazılabilir. 
    // Böylece route her zaman sabit kalır. Mantıklı. 
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }

        // Artık mock repository'ye ihtiyacımız yok.
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo(); 

        // Aşağıda DTO'suz bir end-point örneği var.
        // Bi aşağıda aynı metodun DTO'lu örneği yapıldı.
        // //GET api/commands
        // [HttpGet]
        // public ActionResult <IEnumerable<Command>> GetAllCommands(){
        
        // var commandItems = _repository.GetAllCommands();

        // // return'e dikkat: 
        // // return Ok yazıp içine commandItems listemizi verdik.
        // // -> Bu metodumuz Ienumerable<Command> return ediyordu.
        // // biz de buna uyarak commandItems'ı return ettik:
        // return Ok(commandItems);
        // }

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands(){
        
        var commandItems = _repository.GetAllCommands();

        // return'e dikkat: 
        // return Ok yazıp içine commandItems listemizi verdik.
        // -> Bu metodumuz Ienumerable<Command> return ediyordu.
        // biz de buna uyarak commandItems'ı return ettik:
        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name ="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            // Peki bu end point'in içine   
            // id nereden geliyor? Request'ten geliyor.
            // URI'dan geliyor.
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null){
                // return Ok(commandItem);
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

        // public void CreateCommand(Command cmd){
        //     if(cmd == null){
        //         return new ArgumentNullException(nameof(cmd));
        //     }
        // }

        [HttpPost]  
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto){

            // commandCreateDto'yu Command'a dönüştürüyoruz aşağıda:
            //           .Map To<Command> What is the source? -> (commandCreateDto)
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            // Akılda kalması açısından: 
            _repository.CreateCommand(commandModel);

            // Şu an commandModel objesi istediğimiz değerlere sahip
            // ama db'ye kaydedilmediği için Id = 0 şu an.
            // Aşağıdaki SaveChanges metodunu çağırdığımızda;
            // commandModel'in Id değeri artık 0 olmuyor. Db'ye kaydedilen objenin
            // id değeri commandModel'e yapıştırılıyor.
            // O yüzden return metodundaki new{id = commandReadDto.Id değeri 0 gelmiyor!}
            _repository.SaveChanges(); 
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            // oluşturduğumuz data'nın verilerini return ediyoruz
            // gerekli bir işlem değil. Ama daha iyi bir yol...
            return CreatedAtRoute(nameof(GetCommandById), 
            new {Id = commandReadDto.Id}, commandReadDto); 
             //return Ok(commandReadDto);
        }  
    }
}  