using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
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


        public ActionResult Index(string id)
        {
            return Content("id = " + id + "CurrentUser:" + User.Identity.GetUserName());
        }






        // GET: Conversation
        public JsonResult Conversation(string contact)
        {
            if (Session["user"] == null)
            {
                return Json(new { status = "error", message = "User is not logged in" });
            }

            var currentUser = (Models.UserProfile)Session["user"];

            var conversations = new List<Models.Conversation>();

            conversations = _context.Conversations
                .Where(c => (c.ReceiverId == currentUser.ScreenName
                             && c.SenderId == contact) ||
                            (c.ReceiverId == contact
                             && c.SenderId == currentUser.ScreenName))
                .OrderBy(c => c.CreatedAt)
                .ToList();



            return Json(
                new { status = "success", data = conversations },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}