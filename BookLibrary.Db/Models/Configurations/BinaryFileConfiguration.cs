using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Db.Models.Configurations
{
    internal class BinaryFileConfiguration : EntityConfiguration<BinaryFile>
    {
        public override void Configure(EntityTypeBuilder<BinaryFile> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.FileName)
                .IsRequired(true)
                .HasMaxLength(255);

            builder.Property(i => i.FilePath)
                .IsRequired(true);

            builder.Property(i => i.FileType)
                .HasMaxLength(255);
        }
    }
}
