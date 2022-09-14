using ColTurismoAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ColTurismoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Turista> Turista { get; set; }
        public DbSet<ReservaHotel> ReservaHotel { get; set; }
        public DbSet<Vuelo> Vuelo { get; set; }
        public DbSet<ReservaVuelo> ReservaVuelo { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<ContratoSucursal> ContratoSucursal { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<>
        //}
    }
}
