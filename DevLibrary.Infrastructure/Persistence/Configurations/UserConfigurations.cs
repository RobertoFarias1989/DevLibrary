using DevLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLibrary.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Name)
                .HasMaxLength(100);

            builder
                .Property(u => u.Email)
                .HasMaxLength(100);

            //para que assim não seja possível cadastrar o mesmo email duas vezes
            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.Role)
                .HasMaxLength(100);

            builder
                .Property(u => u.Password)
                .HasMaxLength(100);

            builder
                .HasMany(u => u.Loans)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
