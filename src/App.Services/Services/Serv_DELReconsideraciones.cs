using System;
using System.Data;
using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.DELReconsideraciones;
using App.ViewModels.INSReconsideraciones;
using Dapper;
using Dapper.Oracle;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using static App.ViewModels.DELReconsideraciones.DELReconsideraciones;

namespace App.Services.Services
{
    public class Serv_DELReconsideraciones: IDELReconsideraciones
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;
        public Serv_DELReconsideraciones(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }

        public async Task<Mensaje_Del> EliminarAtencionApo(int N_AAPO_IDNUMREG)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_AAPO_IDNUMREG", N_AAPO_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_DEL_IATENCIONAPO_REC";

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Del>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<Mensaje_Del> EliminarAtencionDia(int N_ADIA_IDNUMREG)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ADIA_IDNUMREG", N_ADIA_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_DEL_IATENCIONDIA_REC";

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Del>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<Mensaje_Del> EliminarAtencionIns(int N_AINS_IDNUMREG)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_AINS_IDNUMREG", N_AINS_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_DEL_IATENCIONINS_REC";

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Del>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<Mensaje_Del> EliminarAtencionMed(int N_AMED_IDNUMREG)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_AMED_IDNUMREG", N_AMED_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_DEL_IATENCIONMED_REC";

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Del>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<Mensaje_Del> EliminarAtencionTotal(int N_ATE_IDNUMREG)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", N_ATE_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_DEL_IATENCIONTOTAL";

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Del>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<Mensaje_Del> EliminarSustento(int N_ASUS_IDNUMREG)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ASUS_IDNUMREG", N_ASUS_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_DEL_IATENCIONSUS";

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Del>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

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

