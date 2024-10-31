
namespace EagleTask.Models.Models.Domains
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<User> Users { get; set; }
        public List<UsersRoles> UsersRoles { get; set; }
    }
}
