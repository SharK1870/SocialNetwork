using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain.Models;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Context;

namespace SocialNetwork.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository, IDisposable
    {
        private SocialNetworkContext context;

        public MessageRepository(SocialNetworkContext context)
        {
            this.context = context;
        }

        public IEnumerable<MessageEntity> GetMessages()
        {
            return context.Messages.ToList();
        }

        public MessageEntity GetMessageById(int id)
        {
            return context.Messages.Find(id);
        }

        public void InsertMessage(MessageEntity message)
        {
            context.Messages.Add(message);
        }

        public void DeleteMessage(int id)
        {
            MessageEntity message = context.Messages.Find(id);
            context.Messages.Remove(message);
        }

        public void UpdateMessage(MessageEntity message)
        {
            context.Entry(message).State = System.Data.Entity.EntityState.Modified;
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
