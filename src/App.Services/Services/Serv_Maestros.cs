using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.Maestros;
using App.ViewModels.SELReconsideraciones;
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

        public async Task<getEESSxID> ListarEESSxID(string V_EESS)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_EESS", V_EESS, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.REC_ATE_EESS_CONSULTA_EESS";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryFirstAsync<getEESSxID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<getPersonalSaludxID> ListarPersSaluxID(string V_DNI)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_DNI", V_DNI, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_PERSONALSALUDXID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryFirstAsync<getPersonalSaludxID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;

            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
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

        public async Task<getServicios> ListarServicios( String V_IDSERVICIO)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_IDSERVICIO", V_IDSERVICIO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_SERVICOS";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryFirstAsync<getServicios>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<GetApoDiagPorID> ListarApoDiagPorId(int IdID_FUA, string V_APO_CODAPO)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ID_FUA", IdID_FUA, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("V_APO_CODAPO", V_APO_CODAPO, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_APODIAG";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryFirstAsync<GetApoDiagPorID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

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
