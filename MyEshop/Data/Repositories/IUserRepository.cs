using MyEshop.Models;
using System.Linq;

namespace MyEshop.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExistUserByEmail(string email);  
        void AddUser(Users user);
        Users GetUserForLogin(string email,string Password);
    }
    public class UserRepository : IUserRepository
    {
        private MyEshopContext _context;
        public UserRepository(MyEshopContext context)
        {
            _context = context;    
        }
        public void AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string email, string Password)
        {
            return _context.Users.SingleOrDefault(u=>u.Email==email && u.Password==Password);  
        }

        public bool IsExistUserByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}
