using DevLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLibrary.Infrastructure.Persistence.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Title)
                .HasMaxLength(254);

            builder
               .Property(b => b.Author)
               .HasMaxLength(100);

            builder
               .Property(b => b.ISBN)
               .HasMaxLength(13);

            //para que assim não seja possível cadastrar dois livros com o mesmo ISBN
            builder
                .HasIndex(b => b.ISBN)
                .IsUnique();

            builder
                .HasMany(b => b.Loans)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.IdBook)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(b => b.Status)
                .HasConversion(typeof(string))
                .HasMaxLength(50);
        }
    }
}
