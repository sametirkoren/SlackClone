using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string Avatar {get;set;}

        [JsonIgnore]
        public ICollection<Message> Messages {get;set;}

        public bool IsOnline{get;set;}
    }
}