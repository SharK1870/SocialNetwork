using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain.Models;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Context;


namespace SocialNetwork.DataAccess.Repositories
{
    public class AuthorizationRepository : IAuthorizationRepository, IDisposable
    {
        private SocialNetworkContext context;

        public AuthorizationRepository(SocialNetworkContext context)
        {
            this.context = context;
        }

        public IEnumerable<Authorization> GetAuthorizations()
        {
            return context.Authorizations.ToList();
        }

        public void DeleteAuthorization(int Id)
        {
            Authorization auth = context.Authorizations.Find(Id);
            context.Authorizations.Remove(auth);
        }

        public Authorization GetAuthorizationById(int Id)
        {
            return context.Authorizations.Find(Id);
        }

        public void InsertAuthorization(Authorization authorization)
        {
            context.Authorizations.Add(authorization);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateAuthorization(Authorization authorization)
        {
            context.Entry(authorization).State = System.Data.Entity.EntityState.Modified;
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
