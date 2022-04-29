namespace Hospitalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        docID = c.Int(nullable: false),
                        ptID = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doctors", t => t.docID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.ptID, cascadeDelete: true)
                .Index(t => t.docID)
                .Index(t => t.ptID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        speciality = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Allergies = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        docID = c.Int(nullable: false),
                        schedule = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doctors", t => t.docID, cascadeDelete: true)
                .Index(t => t.docID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "docID", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "ptID", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "docID", "dbo.Doctors");
            DropIndex("dbo.Schedules", new[] { "docID" });
            DropIndex("dbo.Appointments", new[] { "ptID" });
            DropIndex("dbo.Appointments", new[] { "docID" });
            DropTable("dbo.Schedules");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
