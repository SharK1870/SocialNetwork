using System;
using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.DataAccess.Abstract
{
    public interface IProfileRepository : IDisposable
    {
        IEnumerable<Profile> GetProfiles();
        Profile GetProfileById(int id);
        void InsertProfile(Profile profile);
        void DeleteProfile(int id);
        void UpdateProfile(Profile profile);
        void Save();
    }
}
