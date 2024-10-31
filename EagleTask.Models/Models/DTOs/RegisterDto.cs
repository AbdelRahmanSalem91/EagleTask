
using EagleTask.Models.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace EagleTask.Models.Models.DTOs
{
    public class RegisterDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<Role> Roles { get; set; }
    }
}
