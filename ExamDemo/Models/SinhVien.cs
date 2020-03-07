using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamDemo.Models
{
    public class SinhVien
    {
        public int Id { get; set; }
        public string MaSoSV { get; set; }
        public HinhThuc HinhThuc { get; set; }
        public int SoLuong { get; set; }
        public string NgayPhat { get; set; }
    }
    public enum HinhThuc
    {
        ChongDay,
        PhatTien
    }
}