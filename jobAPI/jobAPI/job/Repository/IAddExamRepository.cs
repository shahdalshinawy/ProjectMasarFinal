using job.DTO;
using job.Models;

namespace job.Repository
{
    public interface IAddExamRepository
    {
        List<exams> GetAll(string id);
		List<exams> GetAllAdminExam();
		void New(AddExamDTO examDTO);
        void Delete(int examId);
        List<QAns> specificExam(int examID);
        List<ExamResults> StudentsResult(int examID);
		

	}
}
