namespace Aircraft.Models
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataTrip { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan TimeDeparture { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan TimeArrival { get; set; }

        [Required]
        [MaxLength(100)]
        public string Departure { get; set; }

        [Required]
        [MaxLength(100)]
        public string Arrival { get; set; }

        public List<Flight> Flights { get; set; }
    }
}
