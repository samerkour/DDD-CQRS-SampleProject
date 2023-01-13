namespace STech.Domain.Commands.Validations
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateFirstName();
            ValidateLastName();
            ValidateBirthDate();
            ValidateEmail();
            ValidateBankAccountNumber();
        }
    }
}