using System.Runtime.Serialization;

namespace ClinicAPI.Exceptions
{
    [Serializable]
    internal class NoDoctorFoundException : Exception
    {
        string message;
        public NoDoctorFoundException()
        {
            message = "No Doctor Found";
        }

        public NoDoctorFoundException(int id)
        {
            message = $"No Doctor Found with This ID: {id}";
        }
        public override string Message => message;
    }
}