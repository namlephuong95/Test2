using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace MVC_Assigment.Models
{
    public class Category
    {
        [Key]
        public int CateId { get; set; }
        public string CateName { get; set; }
        public virtual List<Product> ListProducts { get; set; }
    }
}