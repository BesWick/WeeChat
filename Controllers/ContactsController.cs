using System.Data.Entity;
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

        public ActionResult List()
        {
            var viewModel = _context.WeeUsers.Include(g => g.WeeUser);

            return View(viewModel);
        }
    }
}