using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntityFrame2SqlLib {
    public class VendorRepository {

        private static PRSContext context = new PRSContext();

        public static List<Vendor> GetAll() {

            return context.Vendor.ToList();

        }


        public static Vendor GetByPK(int id) {

            if(id<1) { throw new Exception("Vendor Id must be greater than 0"); }
            return context.Vendor.Find(id);
        }

        public static bool Insert(Vendor vendor) {
            if(vendor==null) { throw new Exception("Vendor instance must not be null"); }
            vendor.Id = 0;
            context.Vendor.Add(vendor);
            return context.SaveChanges() == 1;
        }
        public static bool Update(Vendor vendor) {
            if (vendor == null) { throw new Exception("Vendor instance must not be null"); }
            var dbvendor = context.Vendor.Find(vendor.Id);
            if (dbvendor == null) { throw new Exception("No Vendor with that Id"); }
            dbvendor.Code = dbvendor.Code;
            dbvendor.Name = dbvendor.Name;
            dbvendor.Address = dbvendor.Address;
            dbvendor.City = dbvendor.City;
            dbvendor.State = dbvendor.State;
            dbvendor.Zip = dbvendor.Zip;
            dbvendor.Phone = dbvendor.Phone;
            dbvendor.Email = dbvendor.Email;

            return context.SaveChanges() == 1;

            throw new NotImplementedException();


        }

        public static bool Delete(Vendor vendor) {
            if (vendor == null) { throw new Exception("Vendor instance must not be null"); }
            var dbvendor = context.Vendor.Find(vendor.Id);
            if (dbvendor == null) { throw new Exception("No Vendor with that Id"); }
            context.Vendor.Remove(dbvendor);


            return context.SaveChanges() == 1;
            throw new NotImplementedException();
        }

        public static bool Delete(int id) {
            var vendor = context.Vendor.Find(id);
            if (vendor == null) { return false; }
            var rc = Delete(vendor);
            return rc;
            throw new NotImplementedException();
        }

    }
}
