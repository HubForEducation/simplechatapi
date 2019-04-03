using Microsoft.EntityFrameworkCore;

namespace SimpleChatApi.Controllers
{
    public class MessagesContext : DbContext
    {
        public DbSet<Messages> messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=simplechatapi;Username=postgres;Password=password0");
        }
    }
}
