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
    public class Serv_UPDReconsideraciones : IUPDReconsideraciones
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;
        public Serv_UPDReconsideraciones(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }
        public async Task<bool> ActualizarAtencionesDia(UPDAtencionesDiaDto model)
        {
            try
            {                
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_ADIA_CDX", model.V_ADIA_CDX, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ADIA_CODDIA", model.V_ADIA_CODDIA, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ADIA_TIPODIA", model.V_ADIA_TIPODIA, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ADIA_IDUSUARIOACT", "admin", OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("N_ADIA_IDNUMREG", model.N_ADIA_IDNUMREG, OracleMappingType.Int32, ParameterDirection.Input);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_UPD_IATENCIONDIA";
                var result = await conn.ExecuteAsync(query, dyParam, commandType: CommandType.StoredProcedure);

                //var result = await SqlMapper.ExecuteAsync(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                if (result == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
