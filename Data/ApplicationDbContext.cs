using ItemCatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemCatalogAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<TmplAttrs> tmpl_attrs { get; set; }

    }
}
