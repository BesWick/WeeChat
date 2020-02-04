using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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




        public void Send(string who, string message)
        {
            var name = Context.User.Identity.GetUserName();
            var db = _context;

            var user = _context.WeeUsers.FirstOrDefault(u => u.ScreenName == who);
            Clients.All.addNewMessageToPage(name, message);
            if (user == null)
            {

                Clients.Caller.showErrorMessage("Could not find that user.");
            }
            else
            {

                db.Entry(user)
                    .Collection(u => u.Connections)
                    .Query()
                    .Where(c => c.Connected == true)
                    .Load();

                if (user.Connections == null)
                {
                    Clients.Caller.showErrorMessage("The user is no longer connected.");
                }
                else
                {
                    Clients.All.showErrorMessage("Could not find that user.");
                    foreach (var connection in user.Connections)
                    {
                        // Clients.Client(connection.ConnectionID)
                        //  .addNewMessageToPage(who, message);
                    }
                    // Clients.Caller.addNewMessageToPage(name, message);

                }
            }

        }

        public override Task OnConnected()
        {
            var name = Context.User.Identity.Name;



            var db = _context;

            var user = db.WeeUsers
                .Include(u => u.Connections)
                .SingleOrDefault(u => u.ScreenName == name);

            if (user == null)
            {
                user = new UserProfile()
                {
                    ScreenName = name,
                    Connections = new List<Connection>(),
                    IsConnected = true
                };
                db.WeeUsers.Add(user);
            }

            user.IsConnected = true;


            user.Connections.Add(new Connection
            {
                ConnectionID = Context.ConnectionId,
                UserAgent = Context.Request.Headers["User-Agent"],
                Connected = true,

            });
            db.SaveChanges();

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {




            return base.OnDisconnected(stopCalled);
        }


    }
}