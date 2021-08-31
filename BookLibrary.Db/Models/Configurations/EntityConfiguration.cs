using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Db.Models.Configurations
{
    internal abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(i => i.Id);
        }
    }
}