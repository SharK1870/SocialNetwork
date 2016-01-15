using System;
using System.Data.Entity;
using SocialNetwork.Domain.Models;
using System.Collections.Generic;

namespace SocialNetwork.DataAccess.Context
{
    public class DbContextSeedInitializer : CreateDatabaseIfNotExists<SocialNetworkContext>
    {
        protected override void Seed(SocialNetworkContext context)
        {
            context.SaveChanges();
        }
    }
}
