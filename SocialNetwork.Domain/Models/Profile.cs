﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Models
{
    public class Profile
    {
        public Profile()
        {
            Users = new List<FriendEntity>();
            Friends = new List<FriendEntity>();
            UsersTo = new List<MessageEntity>();
            UsersFrom = new List<MessageEntity>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        
        public virtual Authorization Authorization { get; set; }
        public virtual ICollection<FriendEntity> Users { get; set; }
        public virtual ICollection<FriendEntity> Friends { get; set; }
        public virtual ICollection<MessageEntity> UsersTo { get; set; }
        public virtual ICollection<MessageEntity> UsersFrom { get; set; }
    }
}
