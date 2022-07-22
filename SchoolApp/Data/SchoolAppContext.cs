using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Data
{
    public class SchoolAppContext : DbContext
    {
        public SchoolAppContext (DbContextOptions<SchoolAppContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolApp.Models.AddBook> AddBook { get; set; }

        public DbSet<SchoolApp.Models.DisplayBook> DisplayBook { get; set; }
    }
}
