using Application.DTOs;
using Application.DTOs.CourierDTOs;
using AutoMapper;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Courier
            CreateMap<CreateCourierDTO, Courier>();
            CreateMap<Courier, GetCourierDTO>();
        }
    }
}
