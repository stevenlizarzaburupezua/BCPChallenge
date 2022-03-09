using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain.Seedwork
{
    public interface IStoreProcedureManager
    {
        void Exec(string name, Dictionary<string, object> parameters);

        Task<string> ExecScalarStringAsync(string name, Dictionary<string, object> parameters);

        Task<int> ExecScalarIntAsync(string name, Dictionary<string, object> parameters);

        Task<Guid> ExecScalarGuidAsync(string name, Dictionary<string, object> parameters);

        Task ExecAsync(string name, Dictionary<string, object> parameters);

        List<T> Exec<T>(string name, Dictionary<string, object> parameters) where T : RawDTO;
        List<T> ExecFnc<T>(string name, Dictionary<string, object> parameters) where T : RawDTO;

        Task<List<T>> ExecAsync<T>(string name, Dictionary<string, object> parameters) where T : RawDTO;

        List<Dictionary<string, object>> ExecDynamic(string name, Dictionary<string, object> parameters);
    }
}
