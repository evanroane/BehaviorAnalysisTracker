namespace BAT.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BAT.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<BAT.Models.BATDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        private void AddUsers(ApplicationDbContext context)
        {
            if (!(context.Users.Any(u => u.UserName == "evan.roane@gmail.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "evan.roane@gmail.com", PhoneNumber = "0123456789" };
                var secondUserToInsert = new ApplicationUser { UserName = "jessie.torelli@gmail.com", PhoneNumber = "9876543210" };
                userManager.Create(userToInsert, "password");
                userManager.Create(secondUserToInsert, "password");
            }
            context.SaveChanges();
        }


        protected override void Seed(BAT.Models.BATDbContext context)
        {
            {
                //ApplicationDbContext userContext = new ApplicationDbContext();
                //AddUsers(userContext);    
                
                //context.CodeSets.AddOrUpdate<CodeSet>(i => i.CodeSetID,
                //    new CodeSet
                //    { 
                //        CodeSetOwner = ""
                //    }

                //);
 
                //context.Inputs.AddOrUpdate<Input>(i => i.InputID,
                //new Input
                //    {
                //        InputName = "aggression",
                //        InputType = "event",
                //        InputColor = "btn-default"
                //    }
                //);
                //context.CodeSetPermissions;
                //context.Sessions;
                //context.SessionPermissions;
                //context.BehaviorEvents;


            }
        }
    }
}