using job.DTO;
using job.Models;
using job.Repository;
using Microsoft.AspNetCore.Mvc;

namespace job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QustionController : Controller
    {
        IQuestionRepository questionRepository;
        QustionRepository qsRepository = new QustionRepository();
        public QustionController(IQuestionRepository _question)
        {
            questionRepository = _question;
        }
        [HttpPost("AddQuestion")]
        public IActionResult New(QuestionDTO question)
        {
            DataP data = new DataP();

            if (ModelState.IsValid)
            {
                data.Message = "success";
                data.IsPass = true;
                qsRepository.Add(question);

                return Ok(data);
            }
            else
            {
                data.Message = "no";
                data.IsPass = false;
                return Ok(data);
            }

        }
        [HttpDelete("DeleteQuestion")]
        public IActionResult DeleteQuestion(int questionID)
        {
            qsRepository.Delete(questionID);
            return Ok();
        }

        [HttpGet("getTheQuestionToStudent")]
        public IActionResult getTheQuestionToStudent(int examId)
        {
            List<QAns> questions = questionRepository.getTheQuestionOfThisExam(examId);
            List<QuestionToStudentDTO> questionToStudentDTOs = new List<QuestionToStudentDTO>();
            foreach (QAns question in questions)
            {
                QuestionToStudentDTO quest = new QuestionToStudentDTO();
                quest.questionId = question.Id;
                quest.question = question.question;
                quest.option1 = question.option1;
                quest.option2 = question.option2;
                quest.option3 = question.option3;
                quest.option4 = question.option4;
                questionToStudentDTOs.Add(quest);

            }
            return Ok(questionToStudentDTOs);

        }
        [HttpPut("EditQuestion/{id}")]
        public IActionResult EditQuestion([FromRoute] int id, QAns qAns)
        {
            if (ModelState.IsValid)
            {
                qsRepository.Edit(id, qAns);

                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("OldExam/{id}")]
        public IActionResult Getoldquestion([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                QAns qAns = qsRepository.GetById(id);

                return Ok(qAns);
            }
            return BadRequest(ModelState);
        }


}
}
