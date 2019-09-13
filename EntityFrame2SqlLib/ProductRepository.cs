using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntityFrame2SqlLib {
   public class ProductRepository {

        private static PRSContext context = new PRSContext();

        public static List<Product> GetAll() {

            return context.Product.ToList();





        }

        public static Product GetByPK(int id) {
            if (id < 1) { throw new Exception("Product id must be greater than 0"); }
            return context.Product.Find(id);

        }

        public static bool Insert(Product product) {

            if (product == null) { throw new Exception("Product instance must not be null"); }
            product.Id = 0;
            context.Product.Add(product);
            return context.SaveChanges() == 1;

        }

        public static bool Update(Product product) {
            if (product == null) { throw new Exception("Product instance must not be null"); }
            var dbproduct = context.Product.Find(product.Id);
            if (dbproduct == null) { throw new Exception("No Product with that Id"); }
            dbproduct.PartNbr = product.PartNbr;
            dbproduct.Name = product.Name;
            dbproduct.Price = product.Price;
            dbproduct.Unit = product.Unit;
            dbproduct.PhotoPath = product.PhotoPath;
           


            return context.SaveChanges() == 1;

            throw new NotImplementedException();
        }

        public static bool Delete(Product product) {
            if (product == null) { throw new Exception("Product instance must not be null"); }
            var dbproduct = context.Product.Find(product.Id);
            if (dbproduct == null) { throw new Exception("No Product with that Id"); }
            context.Product.Remove(dbproduct);


            return context.SaveChanges() == 1;
            throw new NotImplementedException();
        }

        public static bool Delete(int id) {
            var product = context.Product.Find(id);
            if (product == null) { return false; }
            var rc = Delete(product);
            return rc;
            throw new NotImplementedException();
        }
    }
}
