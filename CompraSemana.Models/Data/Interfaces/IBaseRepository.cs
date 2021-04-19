using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Interfaces
{
    public interface IBaseRepository
    {
        Task<T> QuerySingleOrDefault<T>(string query, object parameters = null);
        Task<IEnumerable<T>> QueryAll<T>(string query, object parameters = null);
        Task <bool> Execute(string query, object parameters = null);
    }
}
