using AutoMapper;
using STech.Application.ViewModels;
using STech.Domain.Commands;

namespace STech.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.FirstName,c.LastName, c.BirthDate, c.PhoneNumber, c.Email, c.BankAccountNumber));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.FirstName, c.LastName, c.BirthDate, c.PhoneNumber, c.Email, c.BankAccountNumber));
        }
    }
}
