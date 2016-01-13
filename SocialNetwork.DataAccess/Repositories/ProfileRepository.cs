using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain.Models;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Context;

namespace SocialNetwork.DataAccess.Repositories
{
    public class ProfileRepository : IProfileRepository, IDisposable
    {
        private SocialNetworkContext context;

        public ProfileRepository(SocialNetworkContext context)
        {
            this.context = context;
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return context.Profiles.ToList();
        }

        public Profile GetProfileById(int id)
        {
            return context.Profiles.Find(id);
        }

        public void InsertProfile(Profile profile)
        {
            context.Profiles.Add(profile);
        }

        public void DeleteProfile(int id)
        {
            Profile profile = context.Profiles.Find(id);
            context.Profiles.Remove(profile);
        }

        public void UpdateProfile(Profile profile)
        {
            context.Entry(profile).State = System.Data.Entity.EntityState.Modified;
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
