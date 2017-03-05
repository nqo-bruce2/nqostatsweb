using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nqostatsweb.Models;

namespace nqostatsweb.Data
{
    // public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            builder.Entity<MatchTeamStats>()
                .HasOne(p => p.Match)
                .WithMany(b => b.Teams)
                .HasForeignKey(p => p.MatchId)
                .HasPrincipalKey(b => b.Id);

            builder.Entity<MatchPlayerStats>()
                .HasOne(p => p.Player)
                .WithMany(b => b.PlayerStats)
                .HasForeignKey(p => p.PlayerId)
                .HasPrincipalKey(b => b.Id);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Matches> Match { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<MatchPlayerStats> MatchPlayerStats { get; set; }
        public DbSet<MatchTeamStats> MatchTeamStats { get; set; }
    }
}
