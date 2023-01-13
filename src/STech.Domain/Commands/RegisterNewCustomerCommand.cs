using System;
using STech.Domain.Commands.Validations;

namespace STech.Domain.Commands
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(string firstName, string lastName, DateTime birthDate, string phoneNumber, string email, string bankAccountNumber)
        {
            FirstName = firstName;
            LastName= lastName;
            BirthDate = birthDate;
            PhoneNumber= phoneNumber;
            Email = email;
            BankAccountNumber=bankAccountNumber; 
 
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}