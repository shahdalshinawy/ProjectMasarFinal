using job.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace job.Models
{
    public class Profile
    {
        [Key]
        [ForeignKey("AUser")]
        public string Id { set; get; }
       public string ForthName { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsStudent { get; set; }
        public string? userNumber { get; set; }
        public string UserName { get; set; }
        public string NationalID { get; set; }
		
        [DefaultValue(false)]
		public Boolean IsDeleted { get; set; }

		
		[JsonIgnore]
        public virtual ApplicationUser? AUser { get; set; }

        public List<exams> exams { get; set; }


    }
}
