using System;
using System.Data;
using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.SELReconsideraciones;
using App.ViewModels.SELSiasis;
using Dapper;
using Dapper.Oracle;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using static App.ViewModels.SELSiasis.SELSiasis;

namespace App.Services.Services
{
    public class Serv_SELSiasis:ISELSiasis
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;

        public Serv_SELSiasis(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }

        public async Task<IEnumerable<getAtencionAPOObs>> ListarIAtencionAPORecxID(int v_idnumreg)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("v_idnumreg", v_idnumreg, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.SIASIS}.SUP_IATENCIONAPO_CONSULTA";

                var result = await SqlMapper.QueryAsync<getAtencionAPOObs>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getAtencionDIAObs>> ListarIAtencionDIARecxID(int v_idnumreg)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("v_idnumreg", v_idnumreg, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.SIASIS}.SUP_IATENCIONDIA_CONSULTA";

                var result = await SqlMapper.QueryAsync<getAtencionDIAObs>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getAtencionINSObs>> ListarIAtencionINSRecxID(int v_idnumreg)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("v_idnumreg", v_idnumreg, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.SIASIS}.SUP_IATENCIONINS_CONSULTA";

                var result = await SqlMapper.QueryAsync<getAtencionINSObs>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getAtencionMEDObs>> ListarIAtencionMEDRecxID(int v_idnumreg)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("v_idnumreg", v_idnumreg, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.SIASIS}.SUP_IATENCIONMED_CONSULTA";

                var result = await SqlMapper.QueryAsync<getAtencionMEDObs>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getAtencionObsPar>> ListarIAtencionObsParxID(int v_idnumreg, string v_periodo , string v_mes)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("v_idnumreg", v_idnumreg, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("v_periodo", v_periodo, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("v_mes", v_mes, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.SIASIS}.SUP_IOBS_CONSULTA_PARCIALES";

                var result = await SqlMapper.QueryAsync<getAtencionObsPar>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getAtencionObsTot>> ListarIAtencionObsTotxID(int v_idnumreg, string v_periodo, string v_mes)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("v_idnumreg", v_idnumreg, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("v_periodo", v_periodo, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("v_mes", v_mes, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.SIASIS}.SUP_IOBS_CONSULTA_TOTALES";

                var result = await SqlMapper.QueryAsync<getAtencionObsTot>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<getAtencionObs> ListarIAtencionRecxID(int v_idnumreg)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("v_idnumreg", v_idnumreg, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.SIASIS}.SUP_IATENCION_CONSULTA";

                var result = await SqlMapper.QueryAsync<getAtencionObs>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result.First();
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getMasterBruto>> ListarMasterBrutoxID(int v_idnumreg)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("v_idnumreg", v_idnumreg, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.SIASIS}.SUP_CONSULTA_PREC_MASTER_BRUTO";

                var result = await SqlMapper.QueryAsync<getMasterBruto>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getMasterNeto>> ListarMasterNetoxID(int v_idnumreg)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("v_idnumreg", v_idnumreg, OracleMappingType.Int32, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.SIASIS}.SUP_CONSULTA_COSTO_MASTER_NETO";

                var result = await SqlMapper.QueryAsync<getMasterNeto>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

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

