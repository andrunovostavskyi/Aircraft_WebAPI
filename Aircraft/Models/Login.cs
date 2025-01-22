namespace Aircraft.Models
{
    public class Login
    {

        [Required]
        [MaxLength(100)]
        public string UserName {  get; set; }

        [Required]
        [DataType (DataType.Password)]
        public string Password { get; set; }
    }
}
