using System.Collections.Generic;
using WeeChat.Models;

namespace WeeChat.ViewModels
{
    public class ContactViewModel
    {

        public string currentUser { get; set; }
        public IEnumerable<UserProfile> users { get; set; }
    }
}