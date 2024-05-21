using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projet_ASPNET.Models;

namespace projet_ASPNET.Data
{
    public class projet_ASPNETContext : DbContext
    {
        public projet_ASPNETContext (DbContextOptions<projet_ASPNETContext> options)
            : base(options)
        {
        }

        public DbSet<projet_ASPNET.Models.Article> Dbase { get; set; } = default!;
    }
}
