using Microsoft.EntityFrameworkCore;

namespace SignalR.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext( DbContextOptions options ) : base(options)
        {
        }
       public DbSet<Chat> Chats { get; set; }
    }
}
