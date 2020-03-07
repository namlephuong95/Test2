namespace ExamDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSinhVien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SinhViens", "SoLuong", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SinhViens", "SoLuong");
        }
    }
}
