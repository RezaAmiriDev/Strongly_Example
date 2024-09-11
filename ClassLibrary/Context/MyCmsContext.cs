
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class MyCmsContext:DbContext
    {
        public MyCmsContext(DbContextOptions<MyCmsContext> options) : base(options) { }
        public DbSet<GroupPage> Groups { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<PageComment> Commens { get; set; }

        public DbSet<AdminLogIN> adminLogINs { get; set; }
    }
}
