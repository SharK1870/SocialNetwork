using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain.Models;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Context;

namespace SocialNetwork.DataAccess.Repositories
{
    public class FriendRepository : IFriendRepository, IDisposable
    {
        private SocialNetworkContext context;

        public FriendRepository(SocialNetworkContext context)
        {
            this.context = context;
        }

        public IEnumerable<FriendEntity> GetFriends()
        {
            return context.Friends.ToList();
        }

        public FriendEntity GetFriendById(int id)
        {
            return context.Friends.Find(id);
        }

        public void InsertFriend(FriendEntity friend)
        {
            context.Friends.Add(friend);
        }

        public void DeleteFriend(int id)
        {
            FriendEntity friend = context.Friends.Find(id);
            context.Friends.Remove(friend);
        }

        public void UpdateFriend(FriendEntity friend)
        {
            context.Entry(friend).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
