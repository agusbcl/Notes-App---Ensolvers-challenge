using AutoMapper;
using Ensolvers_Challenge.Backend.Models;
using Ensolvers_Challenge.Shared.Dtos.CategoryDtos;
using Ensolvers_Challenge.Shared.Dtos.NoteDtos;

namespace Ensolvers_Challenge.Backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UpdateNoteDto, Note>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore());
            CreateMap<Note, GetNoteDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
