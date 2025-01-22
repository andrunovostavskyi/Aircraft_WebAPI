namespace Aircraft.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public double Price { get;set; }

        [Required]
        public ClassTicket ClassSeat {  get; set; }

        [ForeignKey("flightId")]
        public int flightId { get; set; }
        public Flight flight { get; set; }
    }
}
