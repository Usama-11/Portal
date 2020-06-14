using System.ComponentModel.DataAnnotations;

namespace Portal.API.Dtos
{
    public class StudentForRegisterDto
    {
        [Required]
        public string StudentId { get; set; }
        
        [Required]
        [StringLength(8,MinimumLength=4, ErrorMessage="Must be at least 4 to 8 characters")]
        public string Password { get; set; }
    }
}