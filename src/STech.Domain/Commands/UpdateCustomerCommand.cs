using System;
using STech.Domain.Commands.Validations;

namespace STech.Domain.Commands
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(Guid id, string firstName, string lastName,DateTime birthDate, string phoneNumber, string email,string banckAccountNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PhoneNumber= phoneNumber;
            Email = email;
            BankAccountNumber= banckAccountNumber;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}