using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.SELReconsideraciones;
using Dapper.Oracle;
using Dapper;
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
    public class Serv_INSReconsideraciones : IINSReconsideraciones
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;

        public Serv_INSReconsideraciones(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }
        public async Task<getInsertarAtencionTotal> InsertarAtencionTotal(int Id, string user)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_USUARIOCREA", user, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_INS_IATENCIONTOTAL";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<getInsertarAtencionTotal>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

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
