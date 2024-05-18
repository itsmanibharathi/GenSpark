using System.Diagnostics;

namespace EmployeeRequestTracker.Models.ModelsDTOs
{
    public class ReturnError
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public ReturnError(int statusCode, string message)
        {
            Message = message;
            StatusCode = statusCode;

            Debug.WriteLine($"StatusCode: {statusCode} - Error: {message}");
        }

    }
}
