using System.ComponentModel.DataAnnotations;

namespace web_api_2.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }
        public string Password { get; set; }

    }
}
