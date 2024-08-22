using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Freelancers_API.Models;

public partial class FreelancerDbContext : DbContext
{
    private readonly IConfiguration config;

    public FreelancerDbContext(IConfiguration config)
    {
        this.config = config;

    }

    public FreelancerDbContext(DbContextOptions<FreelancerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("FreelancerDB"));

            //Server=DESKTOP-6TU3L2H; Database=FreelancerDB; Trusted_Connection=True; TrustServerCertificate=Yes; MultipleActiveResultSets=true
        }
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Hobby).HasMaxLength(2000);
            entity.Property(e => e.Mail).HasMaxLength(500);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Skillsets).HasMaxLength(2000);
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
