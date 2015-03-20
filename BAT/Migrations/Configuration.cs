namespace BAT.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BAT.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BAT.Models.BATDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BAT.Models.BATDbContext context)
        {
            //context.BehaviorEvents.A
        }
    }
}
