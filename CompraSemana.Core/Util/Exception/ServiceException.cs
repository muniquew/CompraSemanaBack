using System;

namespace CompraSemana.Core.Util.Exception
{
    public class ServiceException : System.Exception
    {
        public ServiceException(string error) : base(error)
        {

        }
    }
}
