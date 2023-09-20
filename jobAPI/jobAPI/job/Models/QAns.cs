using System.ComponentModel;
using System.Text.Json.Serialization;

namespace job.Models
{
	public class QAns
	{
		public int Id { get; set; }
		[DefaultValue(false)]
		public Boolean IsDeleted { get; set; }
		public int examsId { get; set; }
		[JsonIgnore]
		public exams? exams { get; set; }
		public string question { get; set; }
		public string correctAnswer { get; set; } //1 2 3 4
		public string option1 { get; set; }
		public string option2 { get; set; }
		public string option3 { get; set; }
		public string option4 { get; set; }
		public float questionDegree { get; set; }
	}
}
