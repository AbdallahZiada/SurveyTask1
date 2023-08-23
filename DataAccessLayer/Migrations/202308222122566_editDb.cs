namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.Answers", new[] { "CallSid" });
            DropIndex("dbo.Questions", new[] { "SurveyId" });
            AddColumn("dbo.Answers", "AnswwerText", c => c.String());
            AddColumn("dbo.Answers", "SurveyId", c => c.Int(nullable: false));
            AddColumn("dbo.Surveys", "Date", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Answers", "SurveyId");
            AddForeignKey("dbo.Answers", "SurveyId", "dbo.Surveys", "Id", cascadeDelete: true);
            DropColumn("dbo.Answers", "RecordingUrl");
            DropColumn("dbo.Answers", "Digits");
            DropColumn("dbo.Answers", "CallSid");
            DropColumn("dbo.Answers", "From");
            DropColumn("dbo.Answers", "Timestamp");
            DropColumn("dbo.Questions", "Type");
            DropColumn("dbo.Questions", "Timestamp");
            DropColumn("dbo.Questions", "SurveyId");
            DropColumn("dbo.Surveys", "Title");
            DropColumn("dbo.Surveys", "Timestamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Surveys", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Surveys", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Questions", "SurveyId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Questions", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Answers", "From", c => c.String());
            AddColumn("dbo.Answers", "CallSid", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Answers", "Digits", c => c.String());
            AddColumn("dbo.Answers", "RecordingUrl", c => c.String());
            DropForeignKey("dbo.Answers", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.Answers", new[] { "SurveyId" });
            DropColumn("dbo.Surveys", "Date");
            DropColumn("dbo.Answers", "SurveyId");
            DropColumn("dbo.Answers", "AnswwerText");
            CreateIndex("dbo.Questions", "SurveyId");
            CreateIndex("dbo.Answers", "CallSid");
            AddForeignKey("dbo.Questions", "SurveyId", "dbo.Surveys", "Id", cascadeDelete: true);
        }
    }
}
