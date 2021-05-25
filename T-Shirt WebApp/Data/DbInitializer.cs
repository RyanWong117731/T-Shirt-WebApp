using System;
using T_Shirt_WebApp.Data;
using T_Shirt_WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T_Shirt_WebApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(T_Shirt_WebAppContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.T_Shirts.Any())
            {
                return;   // DB has been seeded
            }

            var T_Shirts = new T_Shirt[]
            {
                new T_Shirt{Name = "Funny", Price = 25, ImagePath = "Comedy.jpeg", },
                new T_Shirt{Name = "amogus", Price = 1, ImagePath = "sus.jpeg"},
            };

            context.T_Shirts.AddRange(T_Shirts);
            context.SaveChanges();

            var UserAccounts = new UserAccount[]
           {
                new UserAccount{FirstName = "Carson", LastName = "Sarson", Email = "Carson@Sarson.com", Address = "A place", Username = "BigEpicCarson", IsAdmin = true},
                new UserAccount{FirstName = "Quan", LastName = "Jone", Email = "Quan7476@gaming.com", Address = "Another place", Username = "MassiveQuan", IsAdmin = false},

           };

            context.UserAccounts.AddRange(UserAccounts);
            context.SaveChanges();

            var Transactions = new Transaction[]
            {
                new Transaction{TShirtID = 1,UserAccountID = 1, TranactionDate = DateTime.Parse("2019-09-01")},
                new Transaction{TShirtID = 2,UserAccountID = 2, TranactionDate = DateTime.Parse("2018-09-01")},
               
            };

            context.Transactions.AddRange(Transactions);
            context.SaveChanges();

           
        }
    }
}
