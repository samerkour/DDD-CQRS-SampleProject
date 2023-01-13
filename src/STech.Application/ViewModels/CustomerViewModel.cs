using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace STech.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The FirstName is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The LastName is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("LastName")]
        public string LastName { get; set; } 

        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato invalido")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The Phone Number is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Bank Account Number is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("BankAccountNumber")]
        public string BankAccountNumber { get; set; }

    }
}
