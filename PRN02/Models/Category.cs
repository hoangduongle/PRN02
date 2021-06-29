using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRN02.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int CategoryID { get; set; }

        [MaxLength(50)]
        public String CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
