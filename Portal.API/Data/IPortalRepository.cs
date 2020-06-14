using System.Collections.Generic;
using System.Threading.Tasks;
using Portal.API.Models;

namespace Portal.API.Data
{
    public interface IPortalRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();  
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(string studentId); 
    }
}