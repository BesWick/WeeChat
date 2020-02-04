using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WeeChat.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserProfile> WeeUsers { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        public DbSet<Connection> Connections { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}