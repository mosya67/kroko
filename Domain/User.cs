using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Name has maxLength = 20")]
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        [MaxLength(20, ErrorMessage = "Password has maxLength = 20")]
        [Required(ErrorMessage = "Password cannot be null")]
        [DataType(DataType.Password, ErrorMessage = "Password is not a password")]
        public string Password { get; set; }
    }
}