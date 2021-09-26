﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Model
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SQL5052.site4now.net; Database=db_a7a466_supunsam;Id=db_a7a466_supunsam_admin;Password=supun3510");
        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Discount> discounts { get; set; }
    }
}
