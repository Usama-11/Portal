using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portal.API.Models;

namespace Portal.API.Data
{
    public class PortalRepository : IPortalRepository
    {
        private readonly DataContext _context;
        public PortalRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Student> GetStudent(string studentId)
        {
            var student = await _context.Students.Include(r => r.Results).FirstOrDefaultAsync(s => s.StudentId == studentId);

            return student;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _context.Students.Include(r => r.Results).ToListAsync();

            return students;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}