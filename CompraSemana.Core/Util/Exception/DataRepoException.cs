using System;

namespace CompraSemana.Core.Util.Exception
{
    public class DataRepoException : System.Exception
    {
        public DataRepoException(string error) : base(error)
        {

        }
    }
}
