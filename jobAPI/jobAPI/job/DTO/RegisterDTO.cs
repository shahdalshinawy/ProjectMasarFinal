using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using job.Models;

namespace job.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string username { get; set; }
        public string FourthName { get; set; }
        public string NationalID { get; set; }
        public string? UserNumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
       
        public bool IsStudent { get; set; }

    }
}
