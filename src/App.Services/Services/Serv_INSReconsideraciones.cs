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
        public async Task<Mensaje_Ins> InsertarAtenMedicamentoRec(getInsertarAtencionMedicamentoRec model)
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
                dyParam.Add("V_AMED_IDUSUARIOCREA", "ADMIN", OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_INS_IATENCIONMED_REC";
                //var result = await conn.ExecuteAsync(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Ins>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;

            }
            catch (Exception ex)
            {
                return null;
                throw ex;

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

        public async Task<Mensaje_Ins> InsertarAtenDiagnostico(getInsertarAtencionDIA model)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ADIA_NUMREGATE", model.N_ADIA_NUMREGATE, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_ADIA_CDX", model.V_ADIA_CDX!, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ADIA_CODDIA", model.V_ADIA_CODDIA!, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ADIA_TIPODIA", model.V_ADIA_TIPODIA!, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ADIA_IDUSUARIOCREA", "ADMIN", OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_INS_IATENCIONDIA_REC";
                //var result = await conn.ExecuteAsync(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Ins>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;

            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }
        }

        public async Task<Mensaje_Ins> InsertarAtenProcedimiento(getInsertarAtencionAPO model)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_AAPO_NUMREGATE", model.N_AAPO_NUMREGATE, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AAPO_CODAPO", model.N_AAPO_CODAPO, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_AAPO_INRODIA", model.V_AAPO_INRODIA!, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("N_AAPO_ICANTPROCED", model.N_AAPO_ICANTPROCED, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AAPO_ICANTEJECUTADA", model.N_AAPO_ICANTEJECUTADA, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AAPO_ITICKET", model.N_AAPO_ITICKET, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AAPO_NPO", model.N_AAPO_NPO, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AAPO_NCOSTOAPLICADO", model.N_AAPO_NCOSTOAPLICADO, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_AAPO_IDUSUARIOCREA", "ADMIN", OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("N_AAPO_APO_ID", model.N_AAPO_APO_ID!, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_INS_IATENCIONAPO_REC";
                //var result = await conn.ExecuteAsync(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Ins>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;

            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }
        }

        public async Task<Mensaje_Ins> InsertarAtenInsumos(getInsertarAtencionINS model)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_AINS_NUMREGATE", model.N_AINS_NUMREGATE, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AINS_INRODIA", model.N_AINS_INRODIA, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_AINS_CODINS", model.V_AINS_CODINS!, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_AINS_CCARACT", model.V_AINS_CCARACT!, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("N_AINS_ICANTPRESCRITA", model.N_AINS_ICANTPRESCRITA, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AINS_ICANTENTREGADA", model.N_AINS_ICANTENTREGADA, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AINS_ITICKET", model.N_AINS_ITICKET, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AINS_NPO", model.N_AINS_NPO, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("N_AINS_NCOSTOAPLICADO", model.N_AINS_NCOSTOAPLICADO, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_AINS_IDUSUARIOCREA", "ADMIN", OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_INS_IATENCIONINS_REC";
                //var result = await conn.ExecuteAsync(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<Mensaje_Ins>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

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
