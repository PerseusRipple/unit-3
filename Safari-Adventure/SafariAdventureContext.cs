using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Safari_Adventure
{
  public partial class SafariAdventureContext : DbContext
  {
    public SafariAdventureContext()
    {
    }

    public SafariAdventureContext(DbContextOptions<SafariAdventureContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql("server=localhost;database=Safari-Adventure");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }
  }
}
