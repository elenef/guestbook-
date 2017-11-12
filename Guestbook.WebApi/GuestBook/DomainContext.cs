﻿using GuestBook.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBook
{
    public class DomainContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<User> Users { get; set; }

        public DomainContext(DbContextOptions<DomainContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Restaurant>()
                .HasMany(l => l.Reviews);

            mb.Entity<User>()
                .HasMany(l => l.Reviews);
        }
    }
}