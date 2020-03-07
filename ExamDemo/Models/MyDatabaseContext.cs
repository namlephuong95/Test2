using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamDemo.Models
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext()
            : base("MyConnectionString")
        {
        }
        public DbSet<SinhVien> SinhVien { get; set; }
    }
}