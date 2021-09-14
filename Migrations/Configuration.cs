namespace Sample_ASP.NET_Site.Migrations
{
    using Sample_ASP.NET_Site.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Sample_ASP.NET_Site.Models.ManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Sample_ASP.NET_Site.Models.ManagerContext";
        }

        protected override void Seed(Sample_ASP.NET_Site.Models.ManagerContext context)
        {
            var clients = new List<Client>
            {
                new Client
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Timestamp = DateTime.Parse("2021-09-14")
                },
                new Client
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Timestamp = DateTime.Parse("2021-09-14")
                }
            };

        }
    }
}
