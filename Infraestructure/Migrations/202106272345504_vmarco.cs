namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vmarco : DbMigration
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
                "dbo.Invoices",
                c => new
                    {
                        invoiceID = c.Int(nullable: false, identity: true),
                        invoicecode = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        total = c.Double(nullable: false),
                        status = c.Boolean(nullable: false),
                        Client_clientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.invoiceID)
                .ForeignKey("dbo.Clients", t => t.Client_clientID, cascadeDelete: true)
                .Index(t => t.Client_clientID);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        invoicedetailID = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        Invoice_invoiceID = c.Int(nullable: false),
                        Product_productID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.invoicedetailID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_invoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_productID, cascadeDelete: true)
                .Index(t => t.Invoice_invoiceID)
                .Index(t => t.Product_productID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "Product_productID", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "Invoice_invoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Client_clientID", "dbo.Clients");
            DropIndex("dbo.InvoiceDetails", new[] { "Product_productID" });
            DropIndex("dbo.InvoiceDetails", new[] { "Invoice_invoiceID" });
            DropIndex("dbo.Invoices", new[] { "Client_clientID" });
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Invoices");
            DropTable("dbo.Clients");
        }
    }
}
