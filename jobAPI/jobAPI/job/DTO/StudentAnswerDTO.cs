using job.Models;

namespace job.DTO
{
	public class StudentAnswerDTO
	{
		
		public int examid { get; set; }
		public string studentId { get; set; }
		public List<lastStudentAnsweDto> qq { get; set; }=new List<lastStudentAnsweDto>();
		//public List<QAns> QAns { get; set; }=new List<QAns>();
		//public List<AnswersIdDTO> answerOfTheQuestions { get; set;}=new List<AnswersIdDTO>();
		
	
	}
	
}
