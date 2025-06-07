using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KnowledgeCheck.DAL.Entities;

namespace KnowledgeCheck.DAL.Data
{
    public class KnowledgeCheckDbContext : IdentityDbContext<User>
    {
        public KnowledgeCheckDbContext(DbContextOptions<KnowledgeCheckDbContext> options)
            : base(options) { }

        public override DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KnowledgeCheckDbContext).Assembly);
        }
    }
}
