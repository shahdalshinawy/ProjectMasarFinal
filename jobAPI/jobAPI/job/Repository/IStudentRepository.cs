using job.Models;

namespace job.Repository
{
    public interface IStudentRepository
    {
        List<Profile> AllStudents();
        void deleteStudent(string id);

    }
}
