using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.AppEntities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public string Code { get; set; }
    }
}

