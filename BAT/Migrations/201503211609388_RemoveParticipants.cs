namespace BAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveParticipants : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Participants", "Participant_ParticipantID", "dbo.Participants");
            DropForeignKey("dbo.Participants", "SessionID", "dbo.Sessions");
            DropIndex("dbo.Participants", new[] { "SessionID" });
            DropIndex("dbo.Participants", new[] { "Participant_ParticipantID" });
            DropTable("dbo.Participants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ParticipantID = c.String(nullable: false, maxLength: 128),
                        SessionID = c.Int(nullable: false),
                        OwnerID = c.String(nullable: false),
                        Participant_ParticipantID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ParticipantID);
            
            CreateIndex("dbo.Participants", "Participant_ParticipantID");
            CreateIndex("dbo.Participants", "SessionID");
            AddForeignKey("dbo.Participants", "SessionID", "dbo.Sessions", "SessionID", cascadeDelete: true);
            AddForeignKey("dbo.Participants", "Participant_ParticipantID", "dbo.Participants", "ParticipantID");
        }
    }
}
