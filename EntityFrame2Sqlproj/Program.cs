using System;
using System.Linq;
using EntityFrame2SqlLib;

namespace EntityFrame2Sqlproj {
    class Program {
        static void Main(string[] args) {
            //always reference the context instance in EF

            var requestline = new RequestLine()

            { }

           


                



                var request = new Request()
                {
                    Id = 0,
                    Description = "Office Supplies",
                    Justification = "My pen doesn't work",
                    RejectionReason = null,
                    DeliveryMode = "Amazonprime",
                    Status = "NEW",
                    Total = 0,
                    UserId = 1




                };
                
                              
                               
                   var success = RequestRepository.Insert(request);
                   Console.WriteLine($"New Request is {request.Id} {request.Description} {request.Justification} {request.RejectionReason} {request.DeliveryMode} {request.Status} {request.Total} {request.UserId}");


                


                //var vendorInsert = new Vendor()
                //{
                //    Code = "AJG",
                //    Name = "All Just Gravy",
                //    Address = "777 Money Lane",
                //    City = "Cincinnati",
                //    State = "Ohio",
                //    Zip = "11111",
                //    Phone = "513-111-1111",
                //    Email = "123money@gmail.com",

                    

                //};
                //context.Vendor.Add(vendorInsert);
                //context.SaveChanges();
                //Console.WriteLine($"New Vendor {vendorInsert.Name} has been added to Vendors");

                //var request = new Request() {
                //    Id = 0,
                //    Description = "A New Request",
                //    Justification = "I don't need one!",
                //    RejectionReason = null,
                //    DeliveryMode = "Pickup",
                //    Status = "NEW",
                //    Total = 0,
                //    //bring back a user instance but only within the id column
                //    UserId = context.User.SingleOrDefault(u => u.Username.Equals("george1")).Id

                //context.Request.Add(request);

                //var request = new Request () { Id = 3, Description = "Another Changed Description"};
                //var dbRequest = context.Request.Find(request.Id);
                //dbRequest.Description = request.Description;

                //dbRequest = context.Request.Find(3);
                ////when removing make sure they are no FK's point to what you're deleting or will get an exception error
                //context.Request.Remove(dbRequest);
                //context.SaveChanges();


                //adds to collection but doesnt change the database in sql
                //var Dellrequest = context.Request.Find(1);
                //Dellrequest.Total = Dellrequest.RequestLine.Sum(l => l.Product.Price * l.Quantity);
                //Console.WriteLine($"{Dellrequest.Description} {Dellrequest.Status} { Dellrequest.Total}");

                //Dellrequest.RequestLine.ToList().ForEach(r1 =>
                //{
                //    Console.WriteLine($"{r1.Product.Name,-10} {r1.Quantity,5} " +
                //        $"{r1.Product.Price.ToString("C"),10} " +
                //        $"{(r1.Product.Price * r1.Quantity).ToString("C"),11}");


                //});
                //context.SaveChanges();
                //var total = context.Request.Sum(r => r.Total);
                //Console.WriteLine($"Total all requests is {total}");





                //takes all instances in Vendor table and puts in array
                //Find is how u read tables by primary key
                //var samsung = context.Vendor.Find(1);

                //Console.WriteLine($"{samsung.Code} {samsung.Name}");

                //Lambda syntax
                //vendors.ForEach(v => Console.WriteLine($"{v.Code} {v.Name}"));

                //var users = context.User.ToList();

                //context can be called anything - it is the instanc of the dbuser
                //var users = from u in context.User.ToList()
                //            where u.Username.Contains("1") || u.Username.Contains("2")
                //select u;

                //    //query syntax
                //    foreach (var user in users)
                //    {
                //        Console.WriteLine($"{user.Username} {user.Firstname} {user.Lastname}");
                //    }
            

        }


        
    }
}
