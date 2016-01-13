using System;
using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.DataAccess.Abstract
{
    public interface IAuthorizationRepository : IDisposable
    {
        IEnumerable<Authorization> GetAuthorizations();
        Authorization GetAuthorizationById(int Id);
        void InsertAuthorization(Authorization authorization);
        void DeleteAuthorization(int Id);
        void UpdateAuthorization(Authorization authorization);
        void Save();
    }
}
