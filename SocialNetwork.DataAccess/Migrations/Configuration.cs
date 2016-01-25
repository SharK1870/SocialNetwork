namespace SocialNetwork.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SocialNetwork.Domain.Models;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<Context.SocialNetworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SocialNetwork.DataAccess.Context.SocialNetworkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Authorizations.RemoveRange(context.Authorizations);
            context.Profiles.RemoveRange(context.Profiles);
            context.Friends.RemoveRange(context.Friends);
            context.Messages.RemoveRange(context.Messages);

            Authorization a1 = new Authorization { Login = "aaa", Password = "aaa" };
            Authorization a2 = new Authorization { Login = "bbb", Password = "bbb" };
            Authorization a3 = new Authorization { Login = "ccc", Password = "ccc" };

            context.Authorizations.Add(a1);
            context.Authorizations.Add(a2);
            context.Authorizations.Add(a3);

            Profile p1 = new Profile { FirstName = "a", LastName = "a", PatronymicName = "a", Birthday = DateTime.Parse("1994-06-25"), City = "a", Contact = "a", Authorization = a1 };
            Profile p2 = new Profile { FirstName = "b", LastName = "b", PatronymicName = "b", Birthday = DateTime.Parse("1994-06-25"), City = "b", Contact = "b", Authorization = a2 };
            Profile p3 = new Profile { FirstName = "c", LastName = "c", PatronymicName = "c", Birthday = DateTime.Parse("1994-06-25"), City = "c", Contact = "c", Authorization = a3 };
            
            context.Profiles.Add(p1);
            context.Profiles.Add(p2);
            context.Profiles.Add(p3);

            context.SaveChanges();
        }
    }
}
