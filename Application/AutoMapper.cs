using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<WriteTodoModel, Todo>();
        }
    }
}