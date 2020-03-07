namespace ExamDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSinhVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaSoSV = c.String(),
                        HinhThuc = c.Int(nullable: false),
                        NgayPhat = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SinhViens");
        }
    }
}
