using Microsoft.AspNetCore.Identity;

using System;

namespace BookLibrary.Db.Models
{
    public class User : IdentityUser<Guid>, IEntity
    {

    }
}
