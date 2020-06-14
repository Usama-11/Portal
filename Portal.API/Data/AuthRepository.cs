using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portal.API.Models;

namespace Portal.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<Admin> AdminLogin(string adminId, string password)
        {
            var admin = await _context.Admin.FirstOrDefaultAsync(x => x.AdminId == adminId);

            if(admin == null)
                return null;
            
            if(!VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt))
                return null;

            return admin;
        }
        public async Task<Admin> AdminRegister(Admin admin, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;

            await _context.Admin.AddAsync(admin);
            await _context.SaveChangesAsync();

            return admin;
        }
        public async Task<Student> Login(string studentId, string password)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);

            if(student == null)
                return null;
            
            if(!VerifyPasswordHash(password, student.PasswordHash, student.PasswordSalt))
                return null;

            return student;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for(int i=0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public  async Task<Student> Register(Student student, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash( password, out passwordHash, out passwordSalt);

            student.PasswordHash = passwordHash;
            student.PasswordSalt = passwordSalt;

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return student;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using(var hmac = new System.Security.Cryptography.HMACSHA512())
           {
               passwordSalt = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           }
        }

        public async Task<bool> UserExists(string studentId)
        {
            if(await _context.Students.AnyAsync(x => x.StudentId == studentId))
                return true;

            return false;
        }

        
    }
}