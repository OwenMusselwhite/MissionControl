using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MissionControl.Models;

namespace MissionControl.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mission> Missions { get; set; }

        public DbSet<CrewMember> CrewMembers { get; set; }
    }
}