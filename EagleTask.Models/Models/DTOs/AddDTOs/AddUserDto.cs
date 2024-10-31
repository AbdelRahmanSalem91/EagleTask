
using System.ComponentModel.DataAnnotations;

namespace EagleTask.Models.Models.DTOs.AddDTOs
{
    public class AddUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
