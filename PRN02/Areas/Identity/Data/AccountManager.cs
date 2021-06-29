using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PRN02.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AccountManager class
    // nhập hàng: 
    /*
        + Model: Product:
            -- id, name,quantity,TotalPrice,dateIn: DataTime?,cateID
                Category:
            -- id, name
               
            
     */
    public class AccountManager : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
    }
}
