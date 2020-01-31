using System;

namespace WeeChat.Models
{
    public class User
    {
        public int Id { get; set; }
        public ApplicationUser WeeUser { get; set; }
        public DateTime DateCreated { get; set; }

    }

}