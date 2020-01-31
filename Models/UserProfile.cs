using System;

namespace WeeChat.Models
{
    public class UserProfile
    {
        public int Id { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string ScreenName { get; set; }

        // public string WeeChatID { get; set; }
        // public ApplicationUser WeeUser { get; set; }

        public DateTime DateCreated { get; set; }

    }

}