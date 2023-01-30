using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.AppEntities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public AppRole()
        {

        }
        public AppRole(string title,string code, string name)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Code = code;
            Name = name;
        }
        public string Code { get; set; }
        public string Title { get; set; }

        
    }
}

