using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace WeeChat.Models
{
    public class ChatHub : Hub
    {

        private ApplicationDbContext _context;

        public ChatHub()
        {
            _context = new ApplicationDbContext();
        }




        public async Task Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            await Clients.User(name).addNewMessageToPage(name, message);
        }




    }
}