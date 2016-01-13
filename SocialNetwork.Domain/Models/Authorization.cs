using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Models
{
    public class Authorization
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
