using Pharm.DLL.Repositories;
using Pharm.DAL.entity;

namespace WebApplication1.VM
{
    public class UserVM
    {
        public string Name { get; set; } = null!;

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public User Register()
        {
            return new User
            {
                Name = Name,
                Password = Password,
                BirthDate = BirthDate,
            };
        }
    }
}