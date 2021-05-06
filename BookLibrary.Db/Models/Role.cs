using Microsoft.AspNetCore.Identity;

using System;

namespace BookLibrary.Db.Models
{
    public class Role : IdentityRole<Guid>, IEntity
    {

    }
}
