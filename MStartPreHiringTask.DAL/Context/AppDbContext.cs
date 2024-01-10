using Microsoft.EntityFrameworkCore;
using MStartPreHiringTask.DAL.Models.Account;
using MStartPreHiringTask.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStartPreHiringTask.DAL.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server = . ; Database = AppDbContext ; Trusted_Connection = true; MultipleActiveResultSets = true;");

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }


    }
}
