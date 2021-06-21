namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        clientID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        dni = c.Int(nullable: false),
                        address = c.String(nullable: false),
                        country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.clientID);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        invoicedetailID = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        subtotal = c.Double(nullable: false),
                        productID_productID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.invoicedetailID)
                .ForeignKey("dbo.Products", t => t.productID_productID, cascadeDelete: true)
                .Index(t => t.productID_productID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        productID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        price = c.Double(nullable: false),
                        stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.productID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        invoiceID = c.Int(nullable: false, identity: true),
                        invoicecode = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        total = c.Double(nullable: false),
                        status = c.Boolean(nullable: false),
                        clientID_clientID = c.Int(nullable: false),
                        invoicedetailID_invoicedetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.invoiceID)
                .ForeignKey("dbo.Clients", t => t.clientID_clientID, cascadeDelete: true)
                .ForeignKey("dbo.InvoiceDetails", t => t.invoicedetailID_invoicedetailID, cascadeDelete: true)
                .Index(t => t.clientID_clientID)
                .Index(t => t.invoicedetailID_invoicedetailID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "invoicedetailID_invoicedetailID", "dbo.InvoiceDetails");
            DropForeignKey("dbo.Invoices", "clientID_clientID", "dbo.Clients");
            DropForeignKey("dbo.InvoiceDetails", "productID_productID", "dbo.Products");
            DropIndex("dbo.Invoices", new[] { "invoicedetailID_invoicedetailID" });
            DropIndex("dbo.Invoices", new[] { "clientID_clientID" });
            DropIndex("dbo.InvoiceDetails", new[] { "productID_productID" });
            DropTable("dbo.Invoices");
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Clients");
        }
    }
}
