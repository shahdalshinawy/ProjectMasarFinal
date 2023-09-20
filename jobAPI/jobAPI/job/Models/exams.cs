using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace job.Models
{
	public class exams
	{
		public int id { get; set; }
		
        [DefaultValue(false)]
		public Boolean IsDeleted { get; set; }
		public string title { get; set; }
        public DateTime dateTime { get; set; }
        public int minDegree { get; set; }
		public int totalDegree { get; set; }
		[JsonIgnore]
		public List<QAns>? qAns { get; set; } = new List<QAns>();
		[JsonIgnore]
		public List<ExamResults>? examResults { get; set; }

		[ForeignKey("Teacher")]
		public string TeacherId { get; set; }
		[JsonIgnore]
		public virtual Profile Teacher { get; set; }
    }
}
