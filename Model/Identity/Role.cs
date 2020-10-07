using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProAgil.WebApi.Model.Identity
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}