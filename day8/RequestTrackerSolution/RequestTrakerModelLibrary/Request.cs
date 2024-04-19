using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrakerModelLibrary
{
    public class Request : IEquatable<Request>
    {
        public int Id { get; set; }
        public string RequestText { get; set; }
        public int Raised_By { get; set; }
        public string Status { get; set; }
        public int Closed_By { get; set; }
        public DateTime RaisedDate { get; set; } = DateTime.Now;
        public DateTime ClosedDate { get; set; }

        public bool Equals(Request? other)
        {
            return Id.Equals(other.Id);
        }
        //public bool Equals(Request? other) => Id.Equals(other.Id);

        public override string ToString()
        {
            return Id + " " + RequestText + " " + Raised_By + " " + Status + " " + Closed_By + " " + RaisedDate + " " + ClosedDate;
        }

        public Request()
        {
            Id = 0;
            RequestText = string.Empty;
            Raised_By = 0;
            Status = string.Empty;
            Closed_By = 0;
            RaisedDate = DateTime.Now;
            ClosedDate = DateTime.Now;
        }


        public Request(int id, string requestText, int raised_By, string status, int closed_By, DateTime raisedDate, DateTime closedDate)
        {
            Id = id;
            RequestText = requestText;
            Raised_By = raised_By;
            Status = status;
            Closed_By = closed_By;
            RaisedDate = raisedDate;
            ClosedDate = closedDate;
        }

        public void BuildRequest()
        {
            Console.Write("Enter Request Text : ");
            RequestText = Console.ReadLine();
            Console.Write("Enter Raised By : ");
            Raised_By = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Status : ");
            Status = Console.ReadLine();
            Console.Write("Enter Closed By : ");
            Closed_By = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Raised Date : ");
            RaisedDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Closed Date : ");
            ClosedDate = Convert.ToDateTime(Console.ReadLine());
        }

        public static int GetRequestIdFromConsole()
        {
            Console.Write("Enter Request Id : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Enter valid Request Id : ");
            }
            return id;
        }

        public static string GetRequestTextFromConsole()
        {
            Console.Write("Enter Request Text : ");
            string requestText = Console.ReadLine();
            while (string.IsNullOrEmpty(requestText))
            {
                Console.Write("Enter valid Request Text : ");
                requestText = Console.ReadLine();
            }
            return requestText;
        }

        public static int GetRaisedByFromConsole()
        {
            Console.Write("Enter Raised By : ");
            int raisedBy;
            while (!int.TryParse(Console.ReadLine(), out raisedBy))
            {
                Console.Write("Enter valid Raised By : ");
            }
            return raisedBy;
        }

        public static string GetStatusFromConsole()
        {
            Console.Write("Enter Status : ");
            string status = Console.ReadLine();
            while (string.IsNullOrEmpty(status))
            {
                Console.Write("Enter valid Status : ");
                status = Console.ReadLine();
            }
            return status;
        }

        public static int GetClosedByFromConsole()
        {
            Console.Write("Enter Closed By : ");
            int closedBy;
            while (!int.TryParse(Console.ReadLine(), out closedBy))
            {
                Console.Write("Enter valid Closed By : ");
            }
            return closedBy;
        }


    }
}
