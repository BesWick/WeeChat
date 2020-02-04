using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace WeeChat.Models
{
    public class UserProfile
    {


        public ApplicationUser AppUser { get; set; }

        [Key, ForeignKey("AppUser")]
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string ScreenName { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Connection> Connection { get; set; }
    }

}