using JalopyJournal.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JalopyJournal.DAL
{
    public class JJContext : DbContext
    {
        public JJContext() : base("JJContext")
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Fuel> Fuel { get; set; }
        public DbSet<OilPlusFilter> OilPlusFilter { get; set; }
        public DbSet<AirFilter> AirFilter { get; set; }
        public DbSet<FuelAdditive> FuelAdditive { get; set; }
        public DbSet<OilAdditive> OilAdditive { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}