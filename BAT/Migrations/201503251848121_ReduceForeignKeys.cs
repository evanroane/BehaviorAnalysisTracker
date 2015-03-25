namespace BAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReduceForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CodeSets", "CodeSet_CodeSetID", "dbo.CodeSets");
            DropForeignKey("dbo.Sessions", "Session_SessionID", "dbo.Sessions");
            DropForeignKey("dbo.BehaviorEvents", "SessionID", "dbo.Sessions");
            DropIndex("dbo.BehaviorEvents", new[] { "SessionID" });
            DropIndex("dbo.CodeSets", new[] { "CodeSet_CodeSetID" });
            DropIndex("dbo.Sessions", new[] { "Session_SessionID" });
            DropColumn("dbo.CodeSets", "CodeSet_CodeSetID");
            DropColumn("dbo.Sessions", "Session_SessionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sessions", "Session_SessionID", c => c.Int());
            AddColumn("dbo.CodeSets", "CodeSet_CodeSetID", c => c.Int());
            CreateIndex("dbo.Sessions", "Session_SessionID");
            CreateIndex("dbo.CodeSets", "CodeSet_CodeSetID");
            CreateIndex("dbo.BehaviorEvents", "SessionID");
            AddForeignKey("dbo.BehaviorEvents", "SessionID", "dbo.Sessions", "SessionID", cascadeDelete: true);
            AddForeignKey("dbo.Sessions", "Session_SessionID", "dbo.Sessions", "SessionID");
            AddForeignKey("dbo.CodeSets", "CodeSet_CodeSetID", "dbo.CodeSets", "CodeSetID");
        }
    }
}
