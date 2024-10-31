
using System.ComponentModel.DataAnnotations;

namespace EagleTask.Models.Models.DTOs.AddDTOs
{
    public class AddCustomerDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "First name can not be more than 50 letters!")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Last name can not be more than 50 letters!")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = "Phone number must be 11 digits!"), 
         MinLength(11, ErrorMessage = "Phone number must be 11 digits!")]
        public string PhoneNumber { get; set; }
    }
}
