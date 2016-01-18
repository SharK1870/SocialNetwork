using System;

namespace SocialNetwork.Domain.Models
{
    public class FriendEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Profile User { get; set; }
        public virtual Profile Friend { get; set; }
    }
}
