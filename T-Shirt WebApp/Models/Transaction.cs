using System;
using System.Collections.Generic;
using System.Linq;
using T_Shirt_WebApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T_Shirt_WebApp.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int TShirtID { get; set; }

        [Display(Name = "User ID")]
        public int UserAccountID { get; set; }
        public DateTime TranactionDate { get; set; }


        public UserAccount UserAccounts { get; set; }
        public T_Shirt T_Shirts { get; set; }
    }
}
