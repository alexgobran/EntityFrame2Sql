using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntityFrame2SqlLib {
    public class RequestLinesRepository {

        private static PRSContext context = new PRSContext();

        private static void RecalculateRequestTotal(int requestId) {

            var request = RequestRepository.GetByPK(requestId);
            request.Total = request.RequestLine.Sum(l => l.Product.Price * l.Quantity);


        }

        public static List<RequestLine> GetAll() {

            return context.RequestLine.ToList();





        }

        public static RequestLine GetByPK(int id) {
            if (id < 1) { throw new Exception("RequestLine id must be greater than 0"); }
            return context.RequestLine.Find(id);

        }

        public static bool Insert(RequestLine requestLine) {

            if (requestLine == null) { throw new Exception("RequestLine instance must not be null"); }
            requestLine.Id = 0;
            context.RequestLine.Add(requestLine);
            RecalculateRequestTotal((int)requestLine.RequestId);
            return context.SaveChanges() == 1;

        }

        public static bool Update(RequestLine requestLine) {
            if (requestLine == null) { throw new Exception("RequestLine instance must not be null"); }
            var dbrequestLine = context.RequestLine.Find(requestLine.Id);
            if (dbrequestLine == null) { throw new Exception("No RequestLine with that Id"); }
            dbrequestLine.Quantity = requestLine.Quantity;




            return context.SaveChanges() == 1;

            throw new NotImplementedException();
        }

        public static bool Delete(RequestLine requestLine) {
            if (requestLine == null) { throw new Exception("RequestLine instance must not be null"); }
            var dbrequestLine = context.RequestLine.Find(requestLine.Id);
            if (dbrequestLine == null) { throw new Exception("No RequestLine with that Id"); }
            context.RequestLine.Remove(dbrequestLine);
            RecalculateRequestTotal((int)requestLine.RequestId);
            return context.SaveChanges() == 1;
            throw new NotImplementedException();
        }

        public static bool Delete(int id) {
            var requestLine = context.RequestLine.Find(id);
            if (requestLine == null) { return false; }
            var rc = Delete(requestLine);
            return rc;
            throw new NotImplementedException();
        }
    }
}
