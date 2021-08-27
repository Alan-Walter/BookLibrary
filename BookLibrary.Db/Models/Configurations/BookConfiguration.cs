using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Db.Models.Configurations
{
    public class BookConfiguration : EntityConfiguration<Book>
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
        }
    }
}