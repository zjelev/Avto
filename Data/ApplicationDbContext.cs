//dotnet ef dbcontext scaffold 'Server=.;Database=Avto;User Id=AspNet;Password=123456;Encrypt=False;MultipleActiveResultSets=true' Microsoft.EntityFrameworkCore.SqlServer --context ApplicationDbContext --context-dir Data --output-dir Data --force
// comment all keys
// import from Avto.mdb with ignoring PK
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
        base.OnModelCreating(modelBuilder); //fixes Error "The entity type 'IdentityUserLogin<string>' requires a primary key to be defined..."

        //modelBuilder.Entity<Kilometri>(entity =>
        //{
        //    //entity.HasNoKey(); // to import Data
        //    entity.HasKey(e => e.Kmid); // ef database update => To change the IDENTITY property of a column, the column needs to be dropped and recreated, so => Do it manually in SSMS

        //    //entity.Property(e => e.Kmid).HasColumnName("KMID");
        //    entity.Property(e => e.Kmname)
        //        .HasMaxLength(50);
        //        //.HasColumnName("KMName");
        //    //entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        //});

        //modelBuilder.Entity<List>(entity =>
        //{
        //    //entity.Property(e => e.ListData).HasColumnType("datetime");
        //    //entity.Property(e => e.ListId).HasColumnName("ListID");
        //    entity.Property(e => e.ListNumber).HasMaxLength(50);
        //    //entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        //});

        //modelBuilder.Entity<Moto>(entity =>
        //{
        //    //entity.Property(e => e.MotoId).HasColumnName("MotoID");
        //    entity.Property(e => e.MotoName).HasMaxLength(50);
        //    entity.Property(e => e.MotoNumber).HasMaxLength(8);
        //    //entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        //});

        //modelBuilder.Entity<Norma>(entity =>
        //{
        //    entity.Property(e => e.Id).HasColumnName("ID");
        //    entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        //    entity.Property(e => e.UserList).HasMaxLength(255);
        //});

        //modelBuilder.Entity<Otdel>(entity =>
        //{
        //    //entity.Property(e => e.OtdelId).HasColumnName("OtdelID");
        //    entity.Property(e => e.OtdelName).HasMaxLength(50);
        //    //entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        //});

        //modelBuilder.Entity<Slujitel>(entity =>
        //{
        //    //entity.Property(e => e.SlujitelId).HasColumnName("SlujitelID");
        //    entity.Property(e => e.SlujitelName).HasMaxLength(80);
        //    //entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        //});

        //modelBuilder.Entity<TipZastrahovka>(entity =>
        //{
        //    entity.HasKey(e => e.TipZastrahovkiId);

        //    //.ToTable("TipZastrahovki");

        //    //entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        //    entity.Property(e => e.TipZastrahovki)
        //        .HasMaxLength(255);
        //        //.HasColumnName("TipZastrahovki");
        //    //entity.Property(e => e.TipZastrahovkiId).HasColumnName("TipZastrahovkiID");
        //});

        //modelBuilder.Entity<Transak>(entity =>
        //{
        //    entity.HasKey(e => e.TransId);
           
        //    //.ToTable("Transak");

        //    //entity.Property(e => e.DateTrans).HasColumnType("datetime");
        //    //entity.Property(e => e.Kmid).HasColumnName("KMID");
        //    //entity.Property(e => e.ListId).HasColumnName("ListID");
        //    //entity.Property(e => e.MotoId).HasColumnName("MotoID");
        //    //entity.Property(e => e.OtdelId).HasColumnName("OtdelID");
        //    //entity.Property(e => e.SlujitelId).HasColumnName("SlujitelID");
        //    //entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        //    //entity.Property(e => e.TransId).HasColumnName("TransID");
        //    entity.Property(e => e.TransNumber).HasMaxLength(50);
        //});

        //modelBuilder.Entity<Zastrahovka>(entity =>
        //{
        //    entity.HasKey(e => e.ZastrahovkiId);

        //    //.ToTable("Zastrahovki");

        //    //entity.Property(e => e.DataEnd).HasColumnType("datetime");
        //    //entity.Property(e => e.DataStart).HasColumnType("datetime");
        //    //entity.Property(e => e.MotoId).HasColumnName("MotoID");
        //    //entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        //    //entity.Property(e => e.TipZastrahovkaId).HasColumnName("TipZastrahovkaID");
        //    //entity.Property(e => e.ZastrahovkiId).HasColumnName("ZastrahovkiID");
        //});

        //OnModelCreatingPartial(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
