using System.Threading.Tasks;
using Portal.API.Models;

namespace Portal.API.Data
{
    public interface IAuthRepository
    {
         Task<Student> Register(Student student, string password);
         Task<Student> Login(string studentname, string password);
         Task<Admin> AdminRegister(Admin admin, string password);
         Task<Admin> AdminLogin(string adminId, string password);
         Task<bool> UserExists(string studentname);
    }
}