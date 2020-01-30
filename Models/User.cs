using System;

namespace WeeChat.Models
{
    public class User
    {
        public int Id { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public DateTime DateCreated { get; set; }

    }

}