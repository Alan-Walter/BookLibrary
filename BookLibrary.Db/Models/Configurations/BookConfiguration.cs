
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
    }
}
