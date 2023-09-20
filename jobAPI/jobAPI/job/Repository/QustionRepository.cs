using job.DTO;
using job.Models;
using Microsoft.EntityFrameworkCore;

namespace job.Repository
{
    public class QustionRepository : IQuestionRepository
    {
        OnlineExamsEntity context = new OnlineExamsEntity();
        public void Add(QuestionDTO qustionDTO)
        {
            QAns qustion = new QAns();
            qustion.examsId = qustionDTO.examsId;
            qustion.question = qustionDTO.question;
            qustion.option1 = qustionDTO.option1;
            qustion.option2 = qustionDTO.option2;
            qustion.option3 = qustionDTO.option3;
            qustion.option4 = qustionDTO.option4;
            qustion.correctAnswer = qustionDTO.correctAnswer;
            qustion.questionDegree = qustionDTO.questionDegree;
            context.QAns.Add(qustion);
            context.SaveChanges();
        }

        public void Delete(int questionid)
        {
			var qustion = context.QAns.FirstOrDefault(e => e.Id == questionid);
			qustion.IsDeleted = true;
			context.SaveChanges();
        }
        public List<QAns> ans(int questionid)
        {
            List<QAns> qq = context.QAns.ToList();
            return qq;
        }

		public List<QAns> getTheQuestionOfThisExam(int examId)
		{
			List<QAns> question=context.QAns.Include(q=>q.exams).Where(e=>e.examsId==examId).ToList();
            return question;
		}
		public void Edit(int questionid, QAns qAns)
		{
			var qustionR = context.QAns.FirstOrDefault(e => e.Id == questionid);
			qustionR.question = qAns.question;
			qustionR.option1 = qAns.option1;
			qustionR.option2 = qAns.option2;
			qustionR.option3 = qAns.option3;
			qustionR.option4 = qAns.option4;
			qustionR.correctAnswer = qAns.correctAnswer;
			qustionR.questionDegree = qAns.questionDegree;
			context.SaveChanges();
		}

        public QAns GetById(int id)
        {
            QAns qAns = context.QAns.FirstOrDefault(e => e.Id == id);
            return qAns;
        }
    }
}
