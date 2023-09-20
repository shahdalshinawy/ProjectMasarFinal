using job.Models;

namespace job.Repository
{
	public class ExamResultRepo : IexamResultRepo
	{
		OnlineExamsEntity context= new OnlineExamsEntity();
		public void addExamResult(ExamResults examResults)
		{
			context.examsResult.Add(examResults);
			context.SaveChanges();
			
		}

		public exams exam(int examId)
		{
			exams exam=context.exams.FirstOrDefault(e=>e.id==examId && e.IsDeleted==false);
			return exam;
		}
        public List<ExamResults> examResults1(string studentId)
        {
            List<ExamResults> examsId = context.examsResult.Where(e => e.IsDeleted == false && e.studentsID == studentId).ToList();
            return examsId;
        }
		public ExamResults examDone(string stdid,int examid)
		{
			ExamResults examdone = context.examsResult.Where(e => e.studentsID == stdid && e.examsId == examid && e.IsDeleted == false).FirstOrDefault();
			return examdone;
        }
    }
}
