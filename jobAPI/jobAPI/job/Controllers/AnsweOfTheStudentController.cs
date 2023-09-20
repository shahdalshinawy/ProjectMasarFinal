using job.DTO;
using job.Models;
using job.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace job.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnsweOfTheStudentController : ControllerBase
	{
		IQuestionRepository questionRepository;
		IexamResultRepo iexamResultRepo;
		public AnsweOfTheStudentController(IQuestionRepository _questionRepository, IexamResultRepo _IexamResultRepo) {
			questionRepository= _questionRepository;
			iexamResultRepo= _IexamResultRepo;
		}
		[HttpPost("AnswerOfTheStudent")]		
		
		public IActionResult TakeTheResultOfTheStudent([FromBody]StudentAnswerDTO answers)
		{
			float score = 0;
			

			List<QAns> CoreectAnswer = questionRepository.ans(answers.examid);
			
			
			
			foreach (QAns answer in CoreectAnswer)
			{

				foreach(lastStudentAnsweDto ans in answers.qq)
				{
					if(answer.Id==ans.questionId)
					{
						if(answer.correctAnswer==ans.studentAnswer)
						{
							score = score + answer.questionDegree;
						}
					}
				}
			}
			FinalResultDTO finalResult = new FinalResultDTO();
			finalResult.totalDegree = iexamResultRepo.exam(answers.examid).totalDegree;
			finalResult.score= score;
			finalResult.minimumDegree = iexamResultRepo.exam(answers.examid).minDegree;

			ExamResults examResults =new ExamResults();
			examResults.resultsOfExam = score;
			examResults.studentsID = answers.studentId;
			examResults.examsId = answers.examid;
			iexamResultRepo.addExamResult(examResults);
			
			return Ok(finalResult);
		}
	}
}
