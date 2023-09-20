using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using job.Models;

namespace job.Models
{
	public class ExamResults
	{
		public int id { get; set; }
		[ForeignKey("students")]
		public string studentsID { get; set; }
		public float resultsOfExam { get; set; }
		[DefaultValue(false)]
		public Boolean IsDeleted { get; set; }
		public Profile? students { get; set; }
        [ForeignKey("exams")]
		public int examsId { get; set; }
		public exams? exams { get; set; }
	
		
	}
}
