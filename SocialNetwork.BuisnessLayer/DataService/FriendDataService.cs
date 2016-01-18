using SocialNetwork.BuisnessLayer.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;

namespace SocialNetwork.BuisnessLayer.DataService
{
    public class FriendDataService : IFriendDataService
    {
        private readonly IRepository<Authorization> _authRepository;
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<FriendEntity> _friendRepository;
        private readonly IRepository<MessageEntity> _messageRepository;

        public FriendDataService(IRepository<Authorization> authRepository, IRepository<Profile> profileRepository, IRepository<FriendEntity> friendRepository, IRepository<MessageEntity> messageRepository)
        {
            _authRepository = authRepository;
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<FriendEntity>> GetAllFriends()
        {
            return await _friendRepository.GetAllQuery().ToListAsync();
        }
    }
}
