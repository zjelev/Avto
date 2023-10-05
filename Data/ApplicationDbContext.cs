//dotnet ef dbcontext scaffold 'Server=.;Database=Avto;User Id=AspNet;Password=123456;Encrypt=False;MultipleActiveResultSets=true' Microsoft.EntityFrameworkCore.SqlServer --context ApplicationDbContext --context-dir Data --output-dir Data --force
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
    }

    public virtual DbSet<Kilometri> Kilometris { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Norma> Normas { get; set; }

    public virtual DbSet<Otdel> Otdels { get; set; }

    public virtual DbSet<Slujiteli> Slujitelis { get; set; }

    public virtual DbSet<TipZastrahovki> TipZastrahovkis { get; set; }

    public virtual DbSet<Transak> Transaks { get; set; }

    public virtual DbSet<Zastrahovki> Zastrahovkis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Avto;User Id=AspNet;Password=123456;Encrypt=False;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //fixes Error "The entity type 'IdentityUserLogin<string>' requires a primary key to be defined..."

        modelBuilder.Entity<Kilometri>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kilometri");

            entity.Property(e => e.Kmid).HasColumnName("KMID");
            entity.Property(e => e.Kmname)
                .HasMaxLength(50)
                .HasColumnName("KMName");
            entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("List");

            entity.Property(e => e.ListData).HasColumnType("datetime");
            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.ListNumber).HasMaxLength(50);
            entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        });

        modelBuilder.Entity<Moto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Moto");

            entity.Property(e => e.MotoId).HasColumnName("MotoID");
            entity.Property(e => e.MotoName).HasMaxLength(50);
            entity.Property(e => e.MotoNumber).HasMaxLength(8);
            entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        });

        modelBuilder.Entity<Norma>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Norma");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TekushtaData).HasColumnType("datetime");
            entity.Property(e => e.UserList).HasMaxLength(255);
        });

        modelBuilder.Entity<Otdel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Otdel");

            entity.Property(e => e.OtdelId).HasColumnName("OtdelID");
            entity.Property(e => e.OtdelName).HasMaxLength(50);
            entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        });

        modelBuilder.Entity<Slujiteli>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Slujiteli");

            entity.Property(e => e.SlujitelId).HasColumnName("SlujitelID");
            entity.Property(e => e.SlujitelName).HasMaxLength(80);
            entity.Property(e => e.TekushtaData).HasColumnType("datetime");
        });

        modelBuilder.Entity<TipZastrahovki>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TipZastrahovki");

            entity.Property(e => e.TekushtaData).HasColumnType("datetime");
            entity.Property(e => e.TipZastrahovki1)
                .HasMaxLength(255)
                .HasColumnName("TipZastrahovki");
            entity.Property(e => e.TipZastrahovkiId).HasColumnName("TipZastrahovkiID");
        });

        modelBuilder.Entity<Transak>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Transak");

            entity.Property(e => e.DateTrans).HasColumnType("datetime");
            entity.Property(e => e.Kmid).HasColumnName("KMID");
            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.MotoId).HasColumnName("MotoID");
            entity.Property(e => e.OtdelId).HasColumnName("OtdelID");
            entity.Property(e => e.SlujitelId).HasColumnName("SlujitelID");
            entity.Property(e => e.TekushtaData).HasColumnType("datetime");
            entity.Property(e => e.TransId).HasColumnName("TransID");
            entity.Property(e => e.TransNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Zastrahovki>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Zastrahovki");

            entity.Property(e => e.DataEnd).HasColumnType("datetime");
            entity.Property(e => e.DataStart).HasColumnType("datetime");
            entity.Property(e => e.MotoId).HasColumnName("MotoID");
            entity.Property(e => e.TekushtaData).HasColumnType("datetime");
            entity.Property(e => e.TipZastrahovkaId).HasColumnName("TipZastrahovkaID");
            entity.Property(e => e.ZastrahovkiId).HasColumnName("ZastrahovkiID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
