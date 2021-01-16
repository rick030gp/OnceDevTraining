using AutoMapper;

namespace OnceDev.Training.Application.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Domain.Customer, Dto.Customer>().ReverseMap();            
        }
    }
}
