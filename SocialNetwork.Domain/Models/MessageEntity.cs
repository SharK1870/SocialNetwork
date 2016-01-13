using System;
namespace SocialNetwork.Domain.Models
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public int UserToId { get; set; }
        public int UserFromId { get; set; }
        public virtual Profile UserFrom { get; set; }
        public virtual Profile UserTo { get; set; }
    }
}
