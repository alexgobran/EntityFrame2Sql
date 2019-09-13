using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntityFrame2SqlLib {
    public class RequestRepository {




        private static PRSContext context = new PRSContext();

        public static string RequestNew = "NEW";
        public static string RequestReview = "REVIEW";
        public static string RequestEdit = "EDIT";
        public static string RequestApproved = "APPROVED";
        public static string RequestRejected = "REJECTED";

        public static List<Request> GetAll() {

            return context.Request.ToList();





        }

        public static Request GetByPK(int id) {
            if (id < 1) { throw new Exception("Request id must be greater than 0"); }
            return context.Request.Find(id);

        }

        public static bool Insert(Request request) {

            if (request == null) { throw new Exception("Request instance must not be null"); }
            request.Id = 0;
            context.Request.Add(request);
            return context.SaveChanges() == 1;

        }

        public static bool Update(Request request) {
            if (request == null) { throw new Exception("Request instance must not be null"); }
            var dbrequest = context.Request.Find(request.Id);
            if (dbrequest == null) { throw new Exception("No Request with that Id"); }
            dbrequest.Description = request.Description;
            dbrequest.Justification = request.Justification;
            dbrequest.RejectionReason = request.RejectionReason;
            dbrequest.DeliveryMode = request.DeliveryMode;
            dbrequest.Status = request.Status;
            dbrequest.Total = request.Total;
            dbrequest.UserId = request.UserId;



            return context.SaveChanges() == 1;

            throw new NotImplementedException();
        }

        public static bool Delete(Request request) {
            if (request == null) { throw new Exception("Request instance must not be null"); }
            var dbrequest = context.Request.Find(request.Id);
            if (dbrequest == null) { throw new Exception("No Request with that Id"); }
            context.Request.Remove(dbrequest);


            return context.SaveChanges() == 1;

        }

        public static bool Delete(int id) {
            var request = context.Request.Find(id);
            var rc = Delete(request);
            return rc;



        }

        public static void Review(int id) {
            SetStatus(id, RequestReview);

        }

        public static void Approve(int id) {
            SetStatus(id, RequestApproved);


        }

        public static void Reject(int id) {
            SetStatus(id, RequestRejected);
        }

        private static void SetStatus(int id, string status) {
            var request = GetByPK(id);

        }

    }


}