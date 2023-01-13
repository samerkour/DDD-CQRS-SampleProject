using System;
using NetDevPack.Domain;

namespace STech.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, string firstName, string lastName, DateTime birthDate, string phoneNumber, string email, string bankAccountNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName= lastName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber= bankAccountNumber;
        }

        // Empty constructor for EF
        protected Customer() { }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }

        public string BankAccountNumber { get; private set; }
    }
}