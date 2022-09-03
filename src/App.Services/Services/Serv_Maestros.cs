using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.Maestros;
using Dapper;
using Dapper.Oracle;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Services
{
    public class Serv_Maestros:IMaestros
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;

        public Serv_Maestros(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }

        public async Task<GetDiagnosticoPorID> ListarDiagnosticoPorId(string V_C10_CODDIA)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_C10_CODDIA", V_C10_CODDIA, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);
                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_CIE10";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetDiagnosticoPorID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result.First();
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getServicios>> ListarServicios()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_SERVICOS";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getServicios>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }


    }
}
