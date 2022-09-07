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
        public async Task<int> InsertarAtenMedicamentoRec(getInsertarAtencionMedicamentoRec model)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_AMED_NUMREGATE", model.N_AMED_NUMREGATE, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_AMED_CODMED", model.V_AMED_CODMED!, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("N_AMED_INRODIA", model.N_AMED_INRODIA, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AMED_ICANTPRESCRITA", model.N_AMED_ICANTPRESCRITA, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AMED_ICANTENTREGADA", model.N_AMED_ICANTENTREGADA, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AMED_NPO", model.N_AMED_NPO, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_AMED_IDUSUARIOCREA", "ADMIN", OracleMappingType.Decimal, ParameterDirection.Input);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_UPD_IATENCIONDIA";
                var result = await conn.ExecuteAsync(query, dyParam, commandType: CommandType.StoredProcedure);

                //var result = await SqlMapper.ExecuteAsync(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return 1;

            }
            catch (Exception ex)
            {
                return 0;
            }
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
