using System;
using NetDevPack.Messaging;

namespace STech.Domain.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public string PhoneNumber { get; protected set; }  
        public string Email { get; protected set; }
        public string BankAccountNumber { get; protected set; }


    }
}