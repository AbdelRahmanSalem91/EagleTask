namespace EagleTask.Models.Models.Domains
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Role> Roles { get; set; }
        public List<UsersRoles> UsersRoles { get; set; }
        public int? ManagerId { get; set; }
        public User Manager { get; set; }
        public ICollection<User> SubUsers { get; set; }
    }
}
