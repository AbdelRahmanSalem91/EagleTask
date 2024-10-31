
namespace EagleTask.Models.Models.Domains
{
    public class UsersRoles
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
