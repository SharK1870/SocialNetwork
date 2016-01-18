using SocialNetwork.Domain.Models;
using System.Data.Entity;
using SocialNetwork.DataAccess.Configurations;

namespace SocialNetwork.DataAccess.Context
{
    public class SocialNetworkContext : DbContext
    {

        public SocialNetworkContext() : base("SocialNetworkDB") { }

        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<FriendEntity> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorizationConfiguration());
            modelBuilder.Configurations.Add(new ProfileConfiguration());
            modelBuilder.Configurations.Add(new FriendConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
