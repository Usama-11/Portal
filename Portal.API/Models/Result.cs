namespace Portal.API.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public int Semester { get; set; }
        public string Course1 { get; set; }
        public string Course2 { get; set; }
        public string Course3 { get; set; }
        public string Course4 { get; set; }
        public string Course5 { get; set; }
        public string Course6 { get; set; }

        public int Marks1 { get; set; }
        public int Marks2 { get; set; }
        public int Marks3 { get; set; }
        public int Marks4 { get; set; }
        public int Marks5 { get; set; }
        public int Marks6 { get; set; }

        public Student student { get; set; }
        public int StudentId { get; set; }

    }
}