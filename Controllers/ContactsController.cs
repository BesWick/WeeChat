using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using WeeChat.Models;

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

            var currentUser = User.Identity.GetUserId();

            var viewModel = _context.WeeUsers
                .Where(u => u.UserId != currentUser)
                .ToList();
            return View(viewModel);
        }
    }
}