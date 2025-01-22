namespace Aircraft.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string NameCompany { get; set; }

        [MaxLength(255)]
        public string NamePlane { get; set; }

        [Required]
        public int CountSeat { get; set; }

        [ForeignKey("tripId")]
        public Guid tripId { get; set; }
        public Trip trip { get; set; }

        public List<Seat> Seats{ get; set; }
    }

}

