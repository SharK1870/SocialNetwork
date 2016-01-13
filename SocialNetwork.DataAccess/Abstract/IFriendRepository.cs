using System;
using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.DataAccess.Abstract
{
    public interface IFriendRepository : IDisposable
    {
        IEnumerable<FriendEntity> GetFriends();
        FriendEntity GetFriendById(int id);
        void InsertFriend(FriendEntity friend);
        void DeleteFriend(int id);
        void UpdateFriend(FriendEntity friend);
        void Save();
    }
}
