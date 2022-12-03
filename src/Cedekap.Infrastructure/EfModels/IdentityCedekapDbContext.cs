using Cedekap.Core.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cedekap.Infrastructure.EfModels
{
    public class IdentityCedekapDbContext : IdentityDbContext<CedekapWebUser>
    {
        public IdentityCedekapDbContext(DbContextOptions<IdentityCedekapDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
