using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntityFrame2SqlLib {
    public class UsersRepository {

        private static PRSContext context = new PRSContext();

        public static List<User> GetAll() {
            
            return context.User.ToList();
           
            
        


        }

        public static User GetByPK(int id) {
            if(id<1) { throw new Exception("User id must be greater than 0"); }
            return context.User.Find(id);
            
        }

        public static bool Insert(User user) {
            
            if(user==null) { throw new Exception("User instance must not be null"); }
            user.Id = 0;
            context.User.Add(user);
            return context.SaveChanges() == 1;

        }

        public static bool Update(User user) {
            if (user == null) { throw new Exception("User instance must not be null"); }
            var dbuser= context.User.Find(user.Id);
            if (dbuser== null) { throw new Exception("No User with that Id"); }
            dbuser.Username = user.Username;
            dbuser.Password = user.Password;

                       
            return context.SaveChanges() == 1;
            
            throw new NotImplementedException();
        }

        public static bool Delete(User user) {
            if (user == null) { throw new Exception("User instance must not be null"); }
            var dbuser = context.User.Find(user.Id);
            if (dbuser == null) { throw new Exception("No User with that Id"); }
            context.User.Remove(dbuser);


            return context.SaveChanges() == 1;
            throw new NotImplementedException();
        }

        public static bool Delete(int id) {
            var user = context.User.Find(id);
            if(user== null) { return false; }
            var rc = Delete(user);
            return rc;
            throw new NotImplementedException();
        }



    }
}
