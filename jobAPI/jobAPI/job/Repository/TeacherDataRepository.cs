using job.Models;

namespace job.Repository
{
    public class TeacherDataRepository : ITeacherDataRepository
    {
        OnlineExamsEntity context = new OnlineExamsEntity();
        public List<Profile> AllTeachers()
        {
            var teachers = context.profile.Where(t => t.IsTeacher == true && t.IsDeleted==false).ToList();
            return teachers;
        }

        public void deleteTeacher(string id)
        {
            Profile profile = context.profile.Where(s => s.Id == id ).FirstOrDefault();
            profile.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
