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
            {
  "codeSetId" : "Classroom Behavior",
  "description" : "Designed to observe a targeted student's behavior during classroom instruction",
  "inputs" : [ {
    "color" : "btn-primary",
    "name" : "Praise"
  }, {
    "color" : "btn-primary",
    "name" : "Reprimand"
  }, {
    "color" : "btn-primary",
    "name" : "OTR"
  }, {
    "color" : "btn-primary",
    "name" : "Response"
  }, {
    "color" : "btn-primary",
    "name" : "Nonresponse"
  }, {
    "color" : "btn-primary",
    "name" : "Verbal_disruptive"
  }, {
    "color" : "btn-primary",
    "name" : "Phys_disruptive"
  }
            
            
            
            //context.CodeSets;
            context.Inputs.AddOrUpdate<Input>(i => i.InputID,
            new Input
                {
                    InputName = "aggression",
                    InputType = "event",
                    InputColor = "btn-default" 
                }





            );
            //context.CodeSetPermissions;
            //context.Sessions;
            //context.SessionPermissions;
            //context.BehaviorEvents;
            
            
        }
    }
}
