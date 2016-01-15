using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IProfileDataService
    {
        Task<IEnumerable<Profile>> GetAllProfiles();
    }
}
