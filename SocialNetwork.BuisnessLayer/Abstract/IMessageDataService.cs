using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IMessageDataService
    {
        Task<IEnumerable<MessageEntity>> GetAllMessages();
    }
}
