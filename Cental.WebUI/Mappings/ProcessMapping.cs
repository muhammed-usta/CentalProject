using AutoMapper;
using Cental.DtoLayer.ProcessDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class ProcessMapping:Profile
    {
        public ProcessMapping()
        {
            CreateMap<Process, ResultProcessDto>().ReverseMap();
            CreateMap<Process, CreateProcessDto>().ReverseMap();
            CreateMap<Process, UpdateProcessDto>().ReverseMap();
        }
    }
}
