namespace BAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BehaviorEvents",
                c => new
                    {
                        BehaviorEventID = c.Int(nullable: false, identity: true),
                        SessionID = c.Int(nullable: false),
                        InputID = c.Int(nullable: false),
                        ObserverID = c.String(nullable: false),
                        Seconds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BehaviorEventID)
                .ForeignKey("dbo.Inputs", t => t.InputID, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionID, cascadeDelete: true)
                .Index(t => t.SessionID)
                .Index(t => t.InputID);
            
            CreateTable(
                "dbo.Inputs",
                c => new
                    {
                        InputID = c.Int(nullable: false, identity: true),
                        CodeSetID = c.Int(nullable: false),
                        InputName = c.String(nullable: false),
                        InputType = c.String(nullable: false),
                        InputColor = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InputID)
                .ForeignKey("dbo.CodeSets", t => t.CodeSetID, cascadeDelete: true)
                .Index(t => t.CodeSetID);
            
            CreateTable(
                "dbo.CodeSets",
                c => new
                    {
                        CodeSetID = c.Int(nullable: false, identity: true),
                        CodeSetName = c.String(nullable: false),
                        CodeSetDescription = c.String(nullable: false),
                        CodeSetOwner = c.String(nullable: false),
                        CodeSet_CodeSetID = c.Int(),
                    })
                .PrimaryKey(t => t.CodeSetID)
                .ForeignKey("dbo.CodeSets", t => t.CodeSet_CodeSetID)
                .Index(t => t.CodeSet_CodeSetID);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        CodeSet = c.Int(nullable: false),
                        OwnerID = c.String(nullable: false),
                        SessionName = c.String(nullable: false),
                        SessionDescription = c.String(nullable: false),
                        Session_SessionID = c.Int(),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.Sessions", t => t.Session_SessionID)
                .Index(t => t.Session_SessionID);
            
            CreateTable(
                "dbo.CodeSetPermissions",
                c => new
                    {
                        CodeSetPermissionID = c.Int(nullable: false, identity: true),
                        OwnerID = c.String(nullable: false),
                        CodeSetID = c.Int(nullable: false),
                        ParticipantID = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CodeSetPermissionID);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ParticipantID = c.String(nullable: false, maxLength: 128),
                        SessionID = c.Int(nullable: false),
                        OwnerID = c.String(nullable: false),
                        Participant_ParticipantID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ParticipantID)
                .ForeignKey("dbo.Participants", t => t.Participant_ParticipantID)
                .ForeignKey("dbo.Sessions", t => t.SessionID, cascadeDelete: true)
                .Index(t => t.SessionID)
                .Index(t => t.Participant_ParticipantID);
            
            CreateTable(
                "dbo.SessionPermissions",
                c => new
                    {
                        PermissionID = c.Int(nullable: false, identity: true),
                        OwnerID = c.String(nullable: false),
                        SessionID = c.Int(nullable: false),
                        ParticipantID = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "SessionID", "dbo.Sessions");
            DropForeignKey("dbo.Participants", "Participant_ParticipantID", "dbo.Participants");
            DropForeignKey("dbo.BehaviorEvents", "SessionID", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "Session_SessionID", "dbo.Sessions");
            DropForeignKey("dbo.BehaviorEvents", "InputID", "dbo.Inputs");
            DropForeignKey("dbo.Inputs", "CodeSetID", "dbo.CodeSets");
            DropForeignKey("dbo.CodeSets", "CodeSet_CodeSetID", "dbo.CodeSets");
            DropIndex("dbo.Participants", new[] { "Participant_ParticipantID" });
            DropIndex("dbo.Participants", new[] { "SessionID" });
            DropIndex("dbo.Sessions", new[] { "Session_SessionID" });
            DropIndex("dbo.CodeSets", new[] { "CodeSet_CodeSetID" });
            DropIndex("dbo.Inputs", new[] { "CodeSetID" });
            DropIndex("dbo.BehaviorEvents", new[] { "InputID" });
            DropIndex("dbo.BehaviorEvents", new[] { "SessionID" });
            DropTable("dbo.SessionPermissions");
            DropTable("dbo.Participants");
            DropTable("dbo.CodeSetPermissions");
            DropTable("dbo.Sessions");
            DropTable("dbo.CodeSets");
            DropTable("dbo.Inputs");
            DropTable("dbo.BehaviorEvents");
        }
    }
}
