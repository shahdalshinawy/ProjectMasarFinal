using job.DTO;
using job.Models;
using Microsoft.EntityFrameworkCore;

namespace job.Repository
{
    public class AddExamRepository : IAddExamRepository
    {
        OnlineExamsEntity context = new OnlineExamsEntity();


        public void Delete(int examID)
        {
            var exam = context.exams.FirstOrDefault(e => e.id == examID);
            exam.IsDeleted=true;
            //context.exams.Remove(exam);
            context.SaveChanges();
        }

        public List<exams> GetAll(string id)
        {
			List<exams> exams = context.exams.Where(e => e.IsDeleted == false && e.TeacherId == id).ToList();
            return exams;
        }
		public List<exams> GetAllAdminExam()
		{
			List<exams> exams = context.exams.Where(e => e.IsDeleted == false).ToList();
			return exams;
		}
		public void New(AddExamDTO examdto)
        {
            exams exam = new exams();
            exam.title = examdto.title;
            exam.dateTime = (DateTime)examdto.dateTime;
            exam.TeacherId=examdto.TeacherId;
            exam.totalDegree = examdto.totalDegree;
            exam.minDegree = examdto.minDegree;
            context.exams.Add(exam);
            context.SaveChanges();
            examdto.id = exam.id;

        }

        public List<QAns> specificExam(int examID)
        {
			var question = context.QAns.Where(e => e.examsId == examID && e.IsDeleted == false).ToList();
			return question;
        }

        public List<ExamResults> StudentsResult(int examID)
        {
            List<ExamResults> examResults = context.examsResult.Include(p=>p.students).Include(p=>p.exams).Where(e => e.examsId == examID && e.IsDeleted==false).ToList();
            return examResults;
        }

    }
}
