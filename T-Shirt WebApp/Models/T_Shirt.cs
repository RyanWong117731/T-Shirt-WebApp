using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;

namespace T_Shirt_WebApp.Models
{
    public class T_Shirt
    {
        public int TShirtID { get; set; } 

        public string Name { get; set; }

        public float Price { get; set; }

        public string ImagePath { get; set; }

        public ICollection <Transaction> Transactions { get; set; }
    }
}
