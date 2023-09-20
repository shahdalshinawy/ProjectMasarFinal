using job.Models;

namespace job.Repository
{
    public interface ITeacherDataRepository
    {
        List<Profile> AllTeachers();
        void deleteTeacher(string id);
    }
}
