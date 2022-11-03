using System;
using System.Data;
using System.Reflection;
using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.INSReconsideraciones;
using Dapper;
using Dapper.Oracle;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;

namespace App.Services.Services
{
    public class Serv_ValRcRvRecosideraciones: IValRcRvRecosideraciones
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;

        public Serv_ValRcRvRecosideraciones(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }

        public async Task<getValidarReglas> ValidarRcRvRec(int N_ATE_IDNUMREG)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", N_ATE_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_VALIDAR_RC_RV";
                //var result = await conn.ExecuteAsync(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<getValidarReglas>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

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

