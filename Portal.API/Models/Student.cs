using System.Collections.Generic;

namespace Portal.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string  StudentId{ get; set; }
        public string StudentName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Semester { get; set; }
        public ICollection<Result> Results { get; set; }
 
    }
}