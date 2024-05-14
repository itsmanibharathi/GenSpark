using System.Runtime.Serialization;

namespace ClinicAPI.Exceptions
{
    [Serializable]
    internal class NoDoctorFoundInThisSpecializationException : Exception
    {
        string message;
        public NoDoctorFoundInThisSpecializationException()
        {
            message = "No doctor found in this specialization";
        }

        public NoDoctorFoundInThisSpecializationException(string? specialization)
        {
            message = $"No doctor found in this specialization: {specialization}";
        }

        public override string Message => message;
    }
}