using AutoMapper;
using PruebaTecnicaLslGestionTareas.DTOs;
using TaskManager.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaTecnicaLslGestionTareas.Mappings
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskItem, TaskResponseDto>();

            CreateMap<TaskCreateDto, TaskItem>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<TaskUpdateDto, TaskItem>();
        }
    }
}
