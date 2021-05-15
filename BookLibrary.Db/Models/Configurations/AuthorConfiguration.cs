using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Db.Models.Configurations
{
    public class AuthorConfiguration : EntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);
            builder.Property(i => i.FirstName)
                .IsRequired(true)
                .HasMaxLength(255);

            builder.Property(i => i.MiddleName)
                .HasMaxLength(255);

            builder.Property(i => i.LastName)
                .IsRequired(true)
                .HasMaxLength(255);
        }
    }
}