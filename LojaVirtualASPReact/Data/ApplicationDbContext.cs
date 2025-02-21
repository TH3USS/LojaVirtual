namespace LojaVirtualASPReact.Data
{
    using Microsoft.EntityFrameworkCore;
    using LojaVirtualASPReact.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }

}
