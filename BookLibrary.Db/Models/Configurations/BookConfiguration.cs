using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Db.Models.Configurations
{
    internal class BookConfiguration : EntityConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);
            builder.Property(i => i.Title)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(i => i.Description)
                .HasMaxLength(512);

            builder.Property(i => i.ImageUrl)
                .HasMaxLength(256);

            builder.HasOne(i => i.Group)
                .WithMany(i => i.Books);

            builder.Property(i => i.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("now() at time zone 'utc'");

            builder.HasMany(i => i.Genres)
                .WithMany(j => j.Books);
        }
    }
}