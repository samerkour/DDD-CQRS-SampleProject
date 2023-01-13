using AutoMapper;
using STech.Application.ViewModels;
using STech.Domain.Models;

namespace STech.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
