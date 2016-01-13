using System;
using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.DataAccess.Abstract
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<MessageEntity> GetMessages();
        MessageEntity GetMessageById(int id);
        void InsertMessage(MessageEntity message);
        void DeleteMessage(int id);
        void UpdateMessage(MessageEntity message);
        void Save();
    }
}
