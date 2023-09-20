using job.Models;
using Microsoft.EntityFrameworkCore;

namespace job.Repository
{
    public class StudentRepository : IStudentRepository
    {
        OnlineExamsEntity context = new OnlineExamsEntity();
        

        public List<Profile> AllStudents()
        {
			List<Profile> students = context.profile.Include(e => e.AUser).Where(t => t.IsStudent == true && t.IsDeleted == false).ToList();
			return students;
        }

        public void deleteStudent(string id)
        {
                Profile profile = context.profile.Where(s => s.Id == id).FirstOrDefault();
                profile.IsDeleted = true;
                context.SaveChanges();
        }
    }
}
