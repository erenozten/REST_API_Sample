using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile(){
            // Source -> Target
            // Yani: Veriyi DB'den okuyoruz ve client'a DTO olarak dönüyoruz...
            CreateMap<Command,CommandReadDto>();
            CreateMap<CommandCreateDto,CommandReadDto>();
        }
    }
}