using System.ComponentModel.DataAnnotations;

namespace job.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        public string password { get; set; }

    }
}
