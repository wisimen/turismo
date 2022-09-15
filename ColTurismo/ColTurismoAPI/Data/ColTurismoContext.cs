using ColTurismo.Common.Helpers;
using ColTurismoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Hosting;

namespace ColTurismoAPI.Data
{
    public class ColTurismoContext : DbContext
    {
        public ColTurismoContext(DbContextOptions<ColTurismoContext> options) : base(options)
        {
        }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Turista> Turista { get; set; }
        public DbSet<ReservaHotel> ReservaHotel { get; set; }
        public DbSet<Vuelo> Vuelo { get; set; }
        public DbSet<ReservaVuelo> ReservaVuelo { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<ContratoSucursal> ContratoSucursal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContratoSucursal>().HasKey(
                c => new { c.CodSucursal, c.CodTurista }
            );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ReservaVuelo>().HasKey(
                r => new { r.NumeroVuelo, r.CodTurista }
            );
            modelBuilder.Entity<ReservaHotel>().HasKey(
                r => new { r.CodTurista, r.CodHotel }
            );
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("time");
        }
    }
}
