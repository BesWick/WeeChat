using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using WeeChat.Models;
using WeeChat.ViewModels;

namespace WeeChat.Controllers
{
    public class ContactsController : Controller
    {
        private ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult List()
        {
            //list of users
            var currentUser = User.Identity.GetUserId();

            var userList = _context.WeeUsers
                .Where(u => u.UserId != currentUser)
                .ToList();

            //current user status

            var dbUser = _context.WeeUsers
                .SingleOrDefault(u => u.UserId == currentUser);


            var viewModel = new ContactViewModel
            {
                currentUser = dbUser.ScreenName,
                users = userList
            };

            return View(viewModel);
        }
    }
}