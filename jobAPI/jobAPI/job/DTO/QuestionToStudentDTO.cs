namespace job.DTO
{
	public class QuestionToStudentDTO
	{
		public int questionId { get; set; }
		
		public string question { get;set; }
		public string option1 { get;set; }
		public string option2 { get;set; }
		public string option3 { get;set; }
		public string option4 { get;set; }
		public string studentAnswer { get;set; }

	}
}
