using job.Models;

namespace job.Repository
{
	public interface IexamResultRepo
	{
		void addExamResult(ExamResults examResults);
		exams exam(int examId);

        public List<ExamResults> examResults1(string studentId);

		public ExamResults examDone(string stid, int examid);
    }
}
