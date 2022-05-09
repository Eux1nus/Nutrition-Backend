using System;

namespace Services
{
    [Serializable]
    public class ServiceErrorException : Exception
    {
        public int ErrorNumber { get; set; }
        public ServiceErrorException()
        {

        }

        public ServiceErrorException(int errorNumber)
        {
            ErrorNumber = errorNumber;
        }
    }
}
