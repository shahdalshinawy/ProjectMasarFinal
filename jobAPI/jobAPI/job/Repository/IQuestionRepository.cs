using job.DTO;
using job.Models;

namespace job.Repository
{
    public interface IQuestionRepository
    {
        void Add(QuestionDTO qustionDTO);
        void Delete(int questionid);
        List<QAns> ans(int questionid);
        QAns GetById(int id);
		void Edit(int questionid, QAns qAns);
		List<QAns> getTheQuestionOfThisExam(int examId);
    }
}
