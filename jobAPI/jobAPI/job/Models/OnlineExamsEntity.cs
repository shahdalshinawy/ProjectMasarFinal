using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using job.Models;

namespace job.Models
{
	public class OnlineExamsEntity : IdentityDbContext<ApplicationUser>
    {
        public OnlineExamsEntity() { }
        public OnlineExamsEntity(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-C91LV05\SQL19;Initial Catalog=MasarDB;Integrated Security=True;Encrypt=False");
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
			{
				relation.DeleteBehavior = DeleteBehavior.NoAction;
			}

			base.OnModelCreating(modelBuilder);
		}
		public DbSet<ExamResults> examsResult { get; set; }
		public DbSet<exams> exams { get; set; }
		public DbSet<Profile> profile { get; set; }
		public DbSet<QAns> QAns { get; set; }
		


	}
}
