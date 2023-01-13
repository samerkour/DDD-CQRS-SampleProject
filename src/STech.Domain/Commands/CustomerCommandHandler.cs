using System;
using System.Threading;
using System.Threading.Tasks;
using STech.Domain.Events;
using STech.Domain.Interfaces;
using STech.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace STech.Domain.Commands
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, ValidationResult>,
        IRequestHandler<UpdateCustomerCommand, ValidationResult>,
        IRequestHandler<RemoveCustomerCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(Guid.NewGuid(), message.FirstName, message.LastName, message.BirthDate, message.PhoneNumber, message.Email, message.BankAccountNumber);

            if (await _customerRepository.GetByEmail(customer.Email) != null)
            {
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRegisteredEvent(customer.Id, customer.FirstName, customer.Email, customer.BirthDate));

            _customerRepository.Add(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(message.Id, message.FirstName, message.LastName, message.BirthDate, message.PhoneNumber, message.Email, message.BankAccountNumber);
            var existingCustomer = await _customerRepository.GetByEmail(customer.Email);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    AddError("The customer e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            customer.AddDomainEvent(new CustomerUpdatedEvent(customer.Id, customer.FirstName, customer.Email, customer.BirthDate));

            _customerRepository.Update(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRemovedEvent(message.Id));

            _customerRepository.Remove(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}