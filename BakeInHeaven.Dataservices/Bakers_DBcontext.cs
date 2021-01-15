using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dataservices.Models;

namespace Dataservices
{
    public class Bakers_DBcontext:DbContext
    {
        public Bakers_DBcontext(DbContextOptions<Bakers_DBcontext> opt):base(opt)
        {
                
        }
        public DbSet<Admins> admins { get; set; }
        public DbSet<delicacys> Delicacys { get; set; }
        public DbSet<delicacy_Schedules> Delicacy_Schedules  { get; set; }
        public DbSet<Orders> orders { get; set; }
}
}
