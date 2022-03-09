using BCP.Domain.Seedwork;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace BCP.Repository.Seedwork
{
    public class SqlServerProcedureManager : BaseProcedureManager, IStoreProcedureManager
    {
        private readonly IConfiguration _configuration;
        public SqlServerProcedureManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string MakeSQLServerParameter(string name) => $"@{name}";
        private string MakeSQLServerParameterWithValue(KeyValuePair<string, object> parameter) => $" {MakeSQLServerParameter(parameter.Key)} = {FormatValue(parameter.Value)}";

        public override string MakeProcedureCallWithValues(string name, Dictionary<string, object> parameters = null)
        {
            return $"exec {name} {MakeParameterListWithValues(parameters, MakeSQLServerParameterWithValue)}".Trim();
        }

        public override string ParameterNameFormat(string name)
        {
            return MakeSQLServerParameter(name);
        }

        public override DbConnection GetDbConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

    }
}
