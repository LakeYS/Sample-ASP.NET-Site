using System.Data.Entity;

namespace Sample_ASP.NET_Site.Models
{
    public class ManagerContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}