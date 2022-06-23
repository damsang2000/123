using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wijimo.Model;

namespace wijimo.Data
{
    public class wijimoContext : DbContext
    {
        public wijimoContext (DbContextOptions<wijimoContext> options)
            : base(options)
        {
        }

        public DbSet<wijimo.Model.Car>? Car { get; set; }
    }
}
