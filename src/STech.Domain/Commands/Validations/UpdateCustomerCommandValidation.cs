namespace STech.Domain.Commands.Validations
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateId();
            ValidateFirstName();
            ValidateLastName();
            ValidateBirthDate();
            ValidateEmail();
            ValidateBankAccountNumber();
        }
    }
}