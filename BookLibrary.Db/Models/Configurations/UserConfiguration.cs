using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace BookLibrary.Db.Models.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        private static readonly Guid AdminUid = Guid.Parse("{0278C83A-3F47-4B60-BF46-9F04690F0C04}");

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            var admin = CreateUser(AdminUid, "admin", "admin");
            builder.HasData(admin);
        }

        private static User CreateUser(Guid id, string name, string password)
        {
            var hasher = new PasswordHasher<User>();

            var user = new User
            {
                Id = id,
                UserName = name,
                NormalizedUserName = name.ToUpper(),
                SecurityStamp = new Guid().ToString("D")
            };

            var passwordHash = hasher.HashPassword(user, password);

            user.PasswordHash = passwordHash;

            return user;
        }
    }
}
