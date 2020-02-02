using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WeeChat.Models;

namespace WeeChat.Controllers
{
    public class ConversationController : Controller
    {
        private ApplicationDbContext _context;


        public ConversationController()
        {
            _context = new ApplicationDbContext();
        }











        // GET: Conversation
        public ActionResult Index(string id)
        {
            ViewBag.target = id;
            ViewBag.user = User.Identity.GetUserName();

            return View();
        }
    }
}