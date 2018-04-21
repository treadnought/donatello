using Donatello.Infrastructure;
using Donatello.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatello.DataAccess
{
    public class DonatelloContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DonatelloContext(DbContextOptions<DonatelloContext> options)
            : base(options) => Database.Migrate();

        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
