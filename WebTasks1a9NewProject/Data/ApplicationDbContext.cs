using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebTasks1a9NewProject.Models;

namespace WebTasks1a9NewProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebTasks1a9NewProject.Models.Exec1> Exec1 { get; set; }
        public DbSet<WebTasks1a9NewProject.Models.Exec2> Exec2 { get; set; }
        public DbSet<WebTasks1a9NewProject.Models.Exec3> Exec3 { get; set; }
        public DbSet<WebTasks1a9NewProject.Models.Exec4> Exec4 { get; set; }
        public DbSet<WebTasks1a9NewProject.Models.Exec5> Exec5 { get; set; }
        public DbSet<WebTasks1a9NewProject.Models.Exec6> Exec6 { get; set; }
        public DbSet<WebTasks1a9NewProject.Models.Exec7> Exec7 { get; set; }
        public DbSet<WebTasks1a9NewProject.Models.Exec8> Exec8 { get; set; }
        public DbSet<WebTasks1a9NewProject.Models.Exec9> Exec9 { get; set; }
    }
}
