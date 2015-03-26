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
                String jessieID = "4926b247-d2b2-4bc0-8123-b436a563a9b6";
                String evanId = "a8fb4721-5bfc-4b1b-8215-80bfa40b15ed";

                ApplicationDbContext userContext = new ApplicationDbContext();
                AddUsers(userContext);

                context.CodeSets.AddOrUpdate<CodeSet>(i => i.CodeSetName,
                    new CodeSet
                    {
                        CodeSetID = 1,
                        CodeSetOwner = jessieID,
                        CodeSetName = "Classroom Behavior",
                        CodeSetDescription = "Designed to observe a targeted student's behavior during classroom instruction"
                    }
                );

                int codeSetID = 6;
                context.Inputs.AddOrUpdate<Input>(i => i.InputName,
                new Input
                    {
                        CodeSetID = codeSetID,
                        InputName = "Praise",
                        InputType = "event",
                        InputColor = "btn-default"
                    },
                
                 new Input
                    {
                        CodeSetID = codeSetID,
                        InputName = "Reprimand",
                        InputType = "event",
                        InputColor = "btn-default"
                    },

                    new Input
                    {
                        CodeSetID = codeSetID,
                        InputName = "OTR",
                        InputType = "event",
                        InputColor = "btn-default"
                    },
                    
                    new Input
                    {
                        CodeSetID = codeSetID,
                        InputName = "Response",
                        InputType = "event",
                        InputColor = "btn-default"
                    },

                    new Input
                    {
                        CodeSetID = codeSetID,
                        InputName = "Nonresponse",
                        InputType = "event",
                        InputColor = "btn-default"
                    },

                    new Input
                    {
                        CodeSetID = codeSetID,
                        InputName = "Verbal_disruptive",
                        InputType = "event",
                        InputColor = "btn-default"
                    },

                    new Input
                    {
                        CodeSetID = codeSetID,
                        InputName = "Phys_disruptive",
                        InputType = "event",
                        InputColor = "btn-default"
                    }
                 );

                context.CodeSetPermissions.AddOrUpdate<CodeSetPermission>(i => i.CodeSetPermissionID,
                    new CodeSetPermission
                    {
                        OwnerID = jessieID,
                        ParticipantID = evanId,
                        CodeSetID = codeSetID
                    }
                );

                context.Sessions.AddOrUpdate<Session>(i => i.SessionName,
                    new Session
                    {
                        OwnerID = jessieID,
                        CodeSet = codeSetID,
                        SessionName = "8675309",
                        SessionDescription = "At location C"
                    }
                );

                context.SessionPermissions.AddOrUpdate<SessionPermission>(i => i.OwnerID,
                    new SessionPermission
                    {
                        OwnerID = jessieID,
                        ParticipantID = evanId,
                        SessionID = 1
                    }
                );

                context.BehaviorEvents.AddOrUpdate<BehaviorEvent>(i => i.Seconds,
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 35,
                        Seconds = 40
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 34,
                        Seconds = 40
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 33,
                        Seconds = 40
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 32,
                        Seconds = 41
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 31,
                        Seconds = 41
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 30,
                        Seconds = 41
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 29,
                        Seconds = 42
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 30,
                        Seconds = 42
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 32,
                        Seconds = 42
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 34,
                        Seconds = 43
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 35,
                        Seconds = 43
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 33,
                        Seconds = 44
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 32,
                        Seconds = 44
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 30,
                        Seconds = 44
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 31,
                        Seconds = 45
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 33,
                        Seconds = 45
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 34,
                        Seconds = 45
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 31,
                        Seconds = 46
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 30,
                        Seconds = 46
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 32,
                        Seconds = 46
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 35,
                        Seconds = 47
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 32,
                        Seconds = 48
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 33,
                        Seconds = 48
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 30,
                        Seconds = 49
                    },
                    new BehaviorEvent
                    {
                        ObserverID = jessieID,
                        SessionID = 3,
                        InputID = 29,
                        Seconds = 49
                    }
                );


            }
        }
    }
}