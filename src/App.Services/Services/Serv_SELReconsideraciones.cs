using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.Auxiliares;
using App.ViewModels.SolicitudRecon;
using Dapper.Oracle;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using App.ViewModels.SELReconsideraciones;
using App.ViewModels.Maestros;

namespace App.Services.Services
{
    public class Serv_SELReconsideraciones : ISELReconsideraciones
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;

        public Serv_SELReconsideraciones(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }

        public async  Task<IEnumerable<getAtencionesDIAxID>> ListarIAtencionDIAxID(int Id)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONDIA_REC";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getAtencionesDIAxID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<getAtencionRecxID> ListarIAtencionRecxID(int Id)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCION_REC";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<getAtencionRecxID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        public async Task<IEnumerable<getAtencionesMEDxID>> ListarIAtencionMEDxID(int Id)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONMED_REC";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getAtencionesMEDxID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        public async Task<IEnumerable<getAtencionesAPOxID>> ListarIAtencionAPOxID(int Id)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONAPO_REC";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getAtencionesAPOxID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        public async Task<IEnumerable<getAtencionesINSxID>> ListarIAtencionINSxID(int Id)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONINS_REC";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getAtencionesINSxID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<getAtencionesDIA_Edit> ListarAtencionDIA_Edit(int Id)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ADIA_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONDIA_REC_ID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<getAtencionesDIA_Edit>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<GetAtencionMedicaRecon> ListarAtencionMedEditxID(int Id)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_AMED_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONMED_REC_ID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<GetAtencionMedicaRecon>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<getAtencionesAPO_Edit> ListarAtencionAPO_Edit(int Id)
        {
                try
                {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("N_AAPO_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONAPO_REC_ID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<getAtencionesAPO_Edit>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //PR_REC_SEL_MEDICAMENTOS
        public async Task<GetMedicamentosxMED_CODMED> ListarMedicamentoxMED_CODMED(string MED_CODMED)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_MED_CODMED", MED_CODMED, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_MEDICAMENTOS";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<GetMedicamentosxMED_CODMED>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<getAtencionesINS_Edit> ListarAtencionINS_Edit(int Id)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_AINS_IDNUMREG", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONINS_REC_ID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<getAtencionesINS_Edit>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetInsumosxId> ListarInsumosId(string V_INS_CODINS)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_INS_CODINS", V_INS_CODINS, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_INSUMOS";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<GetInsumosxId>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetMatriz>> ListarMatriz(int Id)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ATE_NUMREGATE", Id, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_VALMATRIZ";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetMatriz>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<GetResumenxID> ResumenRecxID(int N_ATE_IDNUMREG)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", N_ATE_IDNUMREG, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_RESUMENXID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QuerySingleAsync<GetResumenxID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetObservacionesRcRv>> ListarIAtencionOBSxID(int N_ATE_IDNUMREG, string V_CODTABLA)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", N_ATE_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_CODTABLA", V_CODTABLA, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONOBS_REC_ID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetObservacionesRcRv>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetObservRcRv>> ListarObservacionesRcRv(int N_ATE_IDNUMREG)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", N_ATE_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IOBSERVACIONES_RCRV";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetObservRcRv>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetListObservaAte>> ListarObservacionesSust(int N_ATE_IDNUMREG)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", N_ATE_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONOBSREC_ID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetListObservaAte>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetAteSustento> ListarAteSustxID(int N_ATE_IDNUMREG)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", N_ATE_IDNUMREG, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_ATENCIONXIDSUS";

                var result = await SqlMapper.QuerySingleAsync<GetAteSustento>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<getAteSustentoArch>> ListarAteSusArch(int N_ATE_IDNUMREG)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", N_ATE_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_ATENCIONSUS";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getAteSustentoArch>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<getAteSustentoArch>> ListarAteSusArchxID(int N_ASUS_IDNUMREG)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ASUS_IDNUMREG", N_ASUS_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_IATENCIONSUSXID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getAteSustentoArch>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<getCostosXEVAL> ListarCostosxEVAL(int P_I_IDATENCION)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_I_IDATENCION", P_I_IDATENCION, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_COSTOSXID";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryFirstAsync<getCostosXEVAL>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetEvaluacionID> ListarEvaluacionxID(int P_I_IDATENCION)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_I_IDATENCION", P_I_IDATENCION, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("cv_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_EVALUA";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryFirstAsync<GetEvaluacionID>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
