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

            var currentUser = (Models.UserProfile)Session["user"];

            var viewModel = _context.WeeUsers
                .Where(u => u.ScreenName != currentUser.ScreenName)
                .ToList();
            return View(viewModel);
        }
    }
}