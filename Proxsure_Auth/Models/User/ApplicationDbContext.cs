using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proxsure_Auth.Models.SuscriptionModels;
using Proxsure_Auth.Models.User;
namespace Proxsure_Auth.Models.User {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string> {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
         public DbSet<Suscription> Suscriptions { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<ApplicationUser> ().ToTable ("User");
            modelBuilder.Entity<IdentityRole> ().ToTable ("Role");
            modelBuilder.Entity<IdentityUserClaim<string>> ().ToTable ("UserClaim");
            modelBuilder.Entity<IdentityUserRole<string>> ().ToTable ("UserRole");
            modelBuilder.Entity<IdentityUserLogin<string>> ().ToTable ("UserLogin");
            modelBuilder.Entity<IdentityRoleClaim<string>> ().ToTable ("RoleClaim");
            modelBuilder.Entity<IdentityUserToken<string>> ().ToTable ("UserToken");

        }
    }
}