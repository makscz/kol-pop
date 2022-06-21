using kol_pop.Models;
using Microsoft.EntityFrameworkCore;

namespace kol_pop.Context
{
    public class OrganiztionContext : DbContext
    {
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public OrganiztionContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>(e =>
            {
                e.ToTable("Organization");
                e.HasKey(e => e.OrganizationId);
                e.Property(e=>e.OrganizationName).HasMaxLength(100).IsRequired();
                e.Property(e=>e.OrganizationDomain).HasMaxLength(50).IsRequired();

                e.HasData(new Organization
                {
                    OrganizationId = 1,
                    OrganizationName = "szkola",
                    OrganizationDomain = "naukowa"
                });
            });
            modelBuilder.Entity<Member>(e =>
            {
                e.ToTable("Member");
                e.HasKey(e => e.MemberId);
                e.Property(e=>e.OrganiztionId).IsRequired();
                e.Property(e=>e.MemberName).HasMaxLength(20).IsRequired();
                e.Property(e=>e.MemberSurname).HasMaxLength(50).IsRequired();
                e.Property(e => e.MemmberNickName).HasMaxLength(20);

                
                e.HasOne(e => e.Organiztion).WithMany(e => e.Member).HasForeignKey(e => e.OrganiztionId);

                e.HasData(new Member
                {
                    MemberId = 1,
                    OrganiztionId = 1,
                    MemberName = "kuba",
                    MemberSurname ="kowal",
                    MemmberNickName ="Suzin"
                });
            });
            modelBuilder.Entity<Team>(e =>
            {
                e.ToTable("Team");
                e.HasKey(e=>e.TeamId);
                e.Property(e=>e.OrganizationId).IsRequired();
                e.Property(e=>e.TeamName).HasMaxLength(50).IsRequired();
                e.Property(e => e.TeamDescription).HasMaxLength(500);

                e.HasMany(e=>e.File).WithOne(e=>e.Team).HasForeignKey(e=>e.TeamId);
   
                e.HasOne(e=>e.Organization).WithMany(e => e.Team).HasForeignKey(e => e.OrganizationId);

                e.HasData(new Team
                {
                    TeamId = 1,
                    OrganizationId = 1,
                    TeamName = "kozaki",
                    TeamDescription = "jakies super ludzie"
                });
            });
            modelBuilder.Entity<Membership>(e =>
            {
                e.ToTable("Membership");
                e.HasKey(e => e.MemberId);
                e.Property(e=>e.TeamId).IsRequired();
                e.Property(e=>e.MembershipDate).IsRequired();

                e.HasOne(e=>e.Member).WithMany(e=>e.Membership).HasForeignKey(e => e.MemberId);
                e.HasOne(e => e.Team).WithMany(e => e.Membership).HasForeignKey(e => e.MemberId);

                e.HasData(new Membership
                {
                    MemberId=1,
                    TeamId=1,
                    MembershipDate = System.DateTime.Now
                });
            });
            modelBuilder.Entity<File>(e =>
            {
                e.ToTable("File");
                e.HasKey(e=>new {e.FileId, e.TeamId});
                e.Property(e=>e.FileName).HasMaxLength(100).IsRequired();
                e.Property(e=>e.FileExtension).HasMaxLength(4).IsRequired();
                e.Property(e=>e.FileSize).IsRequired();

                e.HasData(new File
                {
                    FileId=1,
                    TeamId = 1,
                    FileName="zaliczenia",
                    FileExtension="zip",
                    FileSize=100,
                });
            });
        }
    }
}
