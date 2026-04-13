using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using AssetManagement.Models.Entities;

namespace AssetManagement.Data.Context;

public class AppDbContext : DbContext
{
    // Constructor (IMPORTANT for DI)
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Tables
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetAssignment> AssetAssignments { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
    public DbSet<AssetDocument> AssetDocuments { get; set; }

    // Optional: Fluent API configuration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relationship: Employee → User (1:1)
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.User)
            .WithMany() // no collection in User
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MaintenanceLog>()
            .HasOne(m => m.Asset)
            .WithMany()
            .HasForeignKey(m => m.AssetId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AssetDocument>()
            .HasOne(d => d.Asset)
            .WithMany()
            .HasForeignKey(d => d.AssetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}