using SocialNetwork.BuisnessLayer.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;

namespace SocialNetwork.BuisnessLayer.DataService
{
    public class MessageDataService : IMessageDataService
    {
        private readonly IRepository<Authorization> _authRepository;
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<FriendEntity> _friendRepository;
        private readonly IRepository<MessageEntity> _messageRepository;

        public MessageDataService(IRepository<Authorization> authRepository, IRepository<Profile> profileRepository, IRepository<FriendEntity> friendRepository, IRepository<MessageEntity> messageRepository)
        {
            _authRepository = authRepository;
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<MessageEntity>> GetAllMessages()
        {
            return await _messageRepository.GetAllQuery().ToListAsync();
        }
    }
}
