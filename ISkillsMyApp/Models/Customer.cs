using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISkillsMyApp.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]

       
        public int CustomerID { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Please enter First name length between 3 to 10 characters to proceed")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Please enter Last Name length between 3 to 10 characters to proceed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter contactAddress to proceed")]
        public string Address { get; set; }
        
        
        public string City { get; set; }
        
        public string State { get; set; }

       

        public string PostalCode { get; set; }

        
        public string Country { get; set; }
    [Required]
        [RegularExpression(@"((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}",ErrorMessage="Invalid Phone Number")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage="Please provide valid email id")]
        public string Email{ get; set; }

        public string BillingAddress { get; set; }

        public string BillingCity { get; set; }

        public string BillingState { get; set; }
        public string BillingPostalCode { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

       
    }
}