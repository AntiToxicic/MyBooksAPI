using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBooks.Core.Entities;

namespace MyBooks.Infrastructure.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Title).IsRequired();
        
        builder.HasOne(c => c.User)
            .WithMany(c => c.Books)
            .HasForeignKey(c => c.UserId);
    }
}