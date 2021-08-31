using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace BookLibrary.Db.Models.Configurations
{
    internal class AuthorConfiguration : EntityConfiguration<Author>
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

            builder.HasData(new Author
            {
                Id = Guid.Parse("{A0A4703E-05C2-451C-AD8F-9A00963A3998}"),
                FirstName = "Folk",
                LastName = "Art"
            });
        }
    }
}