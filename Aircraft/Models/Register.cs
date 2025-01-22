namespace Aircraft.Models
{
    public class Register
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress] 
        public string EmailAddress { get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
