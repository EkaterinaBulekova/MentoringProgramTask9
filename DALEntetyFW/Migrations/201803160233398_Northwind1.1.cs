namespace DALEntetyFW.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Northwind11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.String(nullable: false, maxLength: 16, fixedLength: true),
                        CardHolderName = c.String(maxLength: 30),
                        ExpirationDate = c.DateTime(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.CreditCards", new[] { "EmployeeID" });
            DropTable("dbo.CreditCards");
        }
    }
}
