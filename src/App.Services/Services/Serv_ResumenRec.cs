using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.SolicitudRecon;
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
    public class Serv_ResumenRec:IResumenRec
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;

        public Serv_ResumenRec(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }

        public async Task<IEnumerable<getResumenReconsDto>> ListarResumenReconsideracion(setResumenReconsDto model)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_IDEESS", model.V_IDEESS, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_PERIODO", model.V_PERIODO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_FILTROFUA", model.V_FILTROFUA, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("V_FUA", model.V_FUA, OracleMappingType.Varchar2, ParameterDirection.Input);

                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = "RECONSIDERACIONES.PR_REC_SEL_RESUMENREC";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getResumenReconsDto>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

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
