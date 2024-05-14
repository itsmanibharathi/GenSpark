using System.Runtime.Serialization;

namespace ClinicAPI.Exceptions
{
    [Serializable]
    internal class EmptyDataBaseException : Exception
    {
        string message;
        public EmptyDataBaseException()
        {
            message = "Empty DataBase";
        }

        public EmptyDataBaseException(string? dbName) 
        {
            message = $"Empty DataBase: {dbName}";
        }
        public override string Message => message;
    }
}