using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KnowledgeCheck.DAL.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(DateTime));

                foreach (var property in properties)
                {
                    property.SetValueConverter(dateTimeConverter);
                }
            }
        }
    }
}
