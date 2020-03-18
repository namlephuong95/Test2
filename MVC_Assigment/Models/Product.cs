using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace MVC_Assigment.Models
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        public string ProdCode { get; set; }
        public string ProdName { get; set; }
        public double ProdPrice { get; set; }
        public string ProdDescription { get; set; }
        public string ProdThumbnail { get; set; }
        [ForeignKey("Category")]
        public int CateId { get; set; }
        public virtual Category Category { get; set; }
    }
}