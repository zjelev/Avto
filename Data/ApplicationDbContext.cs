//dotnet ef dbcontext scaffold 'Server=.;Database=Avto;User Id=AspNet;Password=123456;Encrypt=False;MultipleActiveResultSets=true' Microsoft.EntityFrameworkCore.SqlServer --context ApplicationDbContext --context-dir Data --output-dir Data --force
// Add [DatabaseGenerated(DatabaseGeneratedOption.None)] to all Ids
// Import Data from Avto.mdb
// Remove [DatabaseGenerated(DatabaseGeneratedOption.None)]
// Change Identity Specification > (Is Identity) from No to Yes in SSMS for all PK in all tables 

//using Avto.Data.Enums;
using Avto.Data.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Avto.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.SetCommandTimeout(120);
    }

    public virtual DbSet<PList> Lists { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Otdel> Otdels { get; set; }

    public virtual DbSet<Slujitel> Slujiteli { get; set; }

    public virtual DbSet<Transak> Transaks { get; set; }

    public virtual DbSet<Zastrahovka> Zastrahovki { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Transak>()
        //    .Ignore(t => t.PList); // avoid circular reference

        base.OnModelCreating(modelBuilder); //fixes Error "The entity type 'IdentityUserLogin<string>' requires a primary key to be defined..."
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {

        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");

        base.ConfigureConventions(builder);

    }

    public override int SaveChanges()
    {
        UpdateLitres();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateLitres();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateLitres()
    {
        foreach (var entry in ChangeTracker.Entries())
            if (entry.Entity is PList pList)
            {
                entry.Reference("Moto").Load(); // Eager load the Moto property

                foreach (var transak in pList.Transaks)
                {
                    transak.Litres = (double)(transak.KmId switch
                    {
                        KmId.Основни => pList.Moto.OsnovnaNorma,
                        KmId.Областни => pList.Moto.OkragNorma,
                        KmId.Рудник => pList.Moto.RudnikNorma,
                        KmId.София => pList.Moto.StolicaNorma,
                        KmId.Ремарке => 0,
                        KmId.Място => pList.Moto.MqstoNorma,
                        KmId.Климатик => pList.Moto.KlimatikNorma,
                        KmId.Агрегат => pList.Moto.AgregatNorma,
                        KmId.Климатроник => pList.Moto.KlimaNorma,
                        KmId.Печка => pList.Moto.PechkaNorma,
                        _ => 0
                    } * transak.KmKm) / 100;
                }
            }
    }

    public void UpdateAllLitres(int kmId)
    {
        // select Id, OtdelId, KmId, PListId, KmKm, Litres from dbo.Transaks where KmId = 1 order by PListId desc
        Database.ExecuteSqlRaw($@"
UPDATE Transaks
    SET Litres = COALESCE((CASE 
        WHEN t.KmId = 1 THEN m.OsnovnaNorma
        WHEN t.KmId = 2 THEN m.OkragNorma
        WHEN t.KmId = 3 THEN m.RudnikNorma
        WHEN t.KmId = 4 THEN m.StolicaNorma
        WHEN t.KmId = 6 THEN m.MqstoNorma
        WHEN t.KmId = 7 THEN m.KlimatikNorma
        WHEN t.KmId = 8 THEN m.AgregatNorma
        WHEN t.KmId = 14 THEN m.KlimaNorma
        WHEN t.KmId = 15 THEN m.PechkaNorma
        ELSE 0.0E0
    END * KmKm) / 100.0, 0.0E0)
	FROM Transaks t
	JOIN Motos m ON t.MotoId = m.Id
    WHERE t.KmId = @kmId
    ", new SqlParameter("@kmId", kmId));
    }
}

// SSMS -> Transaks.MotoId & Transaks.SlujitelId allow null

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter()
        : base(dateOnly =>
                dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
    { }
}