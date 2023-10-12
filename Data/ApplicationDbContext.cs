//dotnet ef dbcontext scaffold 'Server=.;Database=Avto;User Id=AspNet;Password=123456;Encrypt=False;MultipleActiveResultSets=true' Microsoft.EntityFrameworkCore.SqlServer --context ApplicationDbContext --context-dir Data --output-dir Data --force
// Add [DatabaseGenerated(DatabaseGeneratedOption.None)] to all Ids
// Import Data from Avto.mdb
// Remove [DatabaseGenerated(DatabaseGeneratedOption.None)]
// Change Identity Specification > (Is Identity) from No to Yes in SSMS for all PK in all tables 

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Avto.Data;

public partial class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.SetCommandTimeout(120);
    }

    public virtual DbSet<Kilometri> Kilometris { get; set; }

    public virtual DbSet<PList> Lists { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Norma> Normas { get; set; }

    public virtual DbSet<Otdel> Otdels { get; set; }

    public virtual DbSet<Slujitel> Slujiteli { get; set; }

    public virtual DbSet<TipZastrahovka> TipZastrahovki { get; set; }

    public virtual DbSet<Transak> Transaks { get; set; }

    public virtual DbSet<Zastrahovka> Zastrahovki { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transak>()
            .Ignore(t => t.PList); // avoid circular reference

        modelBuilder.Entity<Slujitel>()
            .Ignore(t => t.Transaks); // avoid circular reference

        base.OnModelCreating(modelBuilder); //fixes Error "The entity type 'IdentityUserLogin<string>' requires a primary key to be defined..."
    }
}
