namespace Aircraft.Data
{
    public class AircraftContext:IdentityDbContext<AppUser>
    {
        public AircraftContext(DbContextOptions<AircraftContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<Trip> Trips { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Flight> Flights { get; set; }

    }
}
