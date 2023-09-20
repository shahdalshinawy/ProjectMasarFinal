using job.DTO;
using job.Models;
using job.Repository;
using Microsoft.AspNetCore.Mvc;

namespace job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : Controller
    {
        IAddExamRepository addExam;
        AddExamRepository examRepository = new AddExamRepository();
        IexamResultRepo IexamResultRepo;
        public ExamController(IAddExamRepository _addexam, IexamResultRepo iexamResultRepo)
        {
            addExam = _addexam;
            this.IexamResultRepo = iexamResultRepo;
        }
        [HttpPost("AddExam")]
        public IActionResult New(AddExamDTO exam)
        {
            DataP data = new DataP();
           
            if (ModelState.IsValid)
            {
                data.Message = "success";
                data.IsPass = true;
                examRepository.New(exam);

                return Ok(exam.id);
            }
            else
            {
                data.Message = "no";
                data.IsPass = false;
                return Ok(data);
            }

        }
        [HttpDelete("DeleteExam")]
        public IActionResult DeleteExam(int examID)
        {
            examRepository.Delete(examID);
            return Ok();
        }
        [HttpGet("specificexam/{ExamID}")]
        public IActionResult specificExam([FromRoute] int ExamID)
        {
            List<QAns> questions = examRepository.specificExam(ExamID);
            return Ok(questions);
        }
        [HttpGet("Result/{id}")]
        public IActionResult StudentsResult([FromRoute] int id)
        {
            List<ExamResults> examResults = examRepository.StudentsResult(id);
            List<StudentResultDTO> resultdto = new List<StudentResultDTO>();
            foreach(var results in examResults)
            {
                resultdto.Add(new StudentResultDTO
                {
                    examsId=results.examsId,
                    resultsOfExam = results.resultsOfExam,
                    studentsName = results.students.ForthName
                });
            }
            return Ok(resultdto);
        }

        [HttpGet("Exams/{id}")]
        public IActionResult GetAllExam([FromRoute] string id)
        {
            List<exams> exams = examRepository.GetAll(id);
            List<AddExamDTO> addExams = new List<AddExamDTO>();
            foreach (var item in exams)
            {
                AddExamDTO addEx = new AddExamDTO();
                addEx.TeacherId = item.TeacherId;
                addEx.id = item.id;
                addEx.dateTime=item.dateTime;
                addEx.totalDegree = item.totalDegree;
                addEx.minDegree = item.minDegree;
                addEx.title = item.title;
                addExams.Add(addEx);
            }

            return Ok(addExams);
        }
		[HttpGet("ExamsAdmin")]
		public IActionResult GetAllAdminExam()
		{
			List<exams> exams = examRepository.GetAllAdminExam();
            //ExamResults examResults = examRepository.
			List<AddExamDTO> addExams = new List<AddExamDTO>();
			foreach (var item in exams)
			{
				AddExamDTO addEx = new AddExamDTO();
				addEx.TeacherId = item.TeacherId;
				addEx.id = item.id;
				addEx.dateTime = item.dateTime;
				addEx.totalDegree = item.totalDegree;
				addEx.minDegree = item.minDegree;
				addEx.title = item.title;
				addExams.Add(addEx);
			}

			return Ok(addExams);
		}
        [HttpGet("GetExamThatNotExamined")]
        public IActionResult GetTheExamThatNotExamine(string studentId)
        {

            List<ExamResults> examsId = IexamResultRepo.examResults1(studentId);
            List<exams> getExams = examRepository.GetAllAdminExam();


            List<exams> lastRes = new List<exams>();
            foreach (var item in getExams)
            {
                lastRes.Add(item);
            }

            foreach (ExamResults examResults in examsId)
            {
                foreach (exams item in getExams)
                {

                    if (examResults.examsId == item.id)
                    {
                        lastRes.Remove(item);

                    }
                }

            }
            return Ok(lastRes);


        }
        [HttpGet("IsDone")]
        public IActionResult Done(string stdId,int ExamId)
        {
            isDone isDone = new isDone();
            ExamResults exam = IexamResultRepo.examDone(stdId, ExamId);
            if (exam != null)
            {
                isDone.done = true;
            }
            else
            {
                isDone.done = false;
            }
            return Ok(isDone);
        }


    }
}
