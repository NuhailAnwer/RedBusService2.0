using System.ComponentModel.DataAnnotations;

using RedBusService2._0;
namespace RedBusService2._0.Request
{
    public class RegisterRequest
    {


        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string phone { get; set; }

        [Range(18,40)]
        public int Age { get; set; }

        public ChooseRole ChooseRole { get; set; }
    }
    public enum ChooseRole
    {
        Admin = 1, User, Driver
    }
}
