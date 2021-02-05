using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dataservices.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Dataservices
{
    public class Bakers_DBcontext:IdentityDbContext
    {
        public Bakers_DBcontext(DbContextOptions<Bakers_DBcontext> opt):base(opt)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Admins> admins { get; set; }
        public DbSet<delicacys> Delicacys { get; set; }
        public DbSet<delicacy_Schedules> Delicacy_Schedules  { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Sessions> sessions { get; set; }
}
}
