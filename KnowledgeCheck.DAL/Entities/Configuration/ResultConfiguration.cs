using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeCheck.DAL.Entities.Configuration
{
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Score)
                .IsRequired();

            builder.Property(r => r.TakenAt)
                .HasDefaultValueSql("NOW()");

            builder.HasOne(r => r.User)
                .WithMany() 
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Test)
                .WithMany() 
                .HasForeignKey(r => r.TestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
