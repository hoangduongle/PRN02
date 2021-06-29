using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRN02.Models
{   //quantity,TotalPrice,dateIn: DataTime?,cateID
    public class Product
    {
        [Required]
        [Key]
        public int ProductID { get; set; }

        [MaxLength(50)]
        public String ProductName { get; set; }

        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public DateTime DateIn { get; set; }

        [ForeignKey("CateID")]
        public int CategoryID { get; set; }

        public virtual Category CateID { get; set; }

    }
}
