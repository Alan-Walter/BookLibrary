using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace BookLibrary.Db.Models.Configurations
{
    public class BookGroupConfiguration : EntityConfiguration<BookGroup>
    {
        public static readonly Guid AllGroupId = Guid.Parse("{18626CA0-6D3D-4F8A-AB66-A39534723548}");

        public override void Configure(EntityTypeBuilder<BookGroup> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.Title)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(i => i.Parent)
                .WithMany(i => i.Childs);

            builder.HasData(new BookGroup
            {
                Id = AllGroupId,
                Title = "All"
            });
        }
    }
}
