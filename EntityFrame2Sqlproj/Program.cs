using System;
using System.Linq;
using EntityFrame2SqlLib;

namespace EntityFrame2Sqlproj {
    class Program {
        static void Main(string[] args) {
            //always reference the context instance in EF
            
            using (var context = new PRSContext()) {
                //takes all instances in Vendor table and puts in array
                //Find is how u read tables by primary key
                var samsung = context.Vendor.Find(1);

                Console.WriteLine($"{samsung.Code} {samsung.Name}");

                //Lambda syntax
                //vendors.ForEach(v => Console.WriteLine($"{v.Code} {v.Name}"));

                var users = context.User.ToList();

            

            //    //query syntax
            ////    foreach (var user in users)
            ////    {
            ////    Console.WriteLine($"{user.Username} {user.Firstname} {user.Lastname}");
            ////      }

            }

            
        }
    }
}
