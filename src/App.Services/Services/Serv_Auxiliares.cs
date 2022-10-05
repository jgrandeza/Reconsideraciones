using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.Auxiliares;
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
    public class Serv_Auxiliares:IAuxiliares
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;

        public Serv_Auxiliares(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }

        public async Task<IEnumerable<getComponentes>> ListarComponentes()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_COMPONENTES";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getComponentes>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getTipoDocIdentidad>> ListarTipoDocIdentidad()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_TIPODOCIDENTIDAD";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getTipoDocIdentidad>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        public async Task<IEnumerable<getSexo>> ListarSexo()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_SEXO";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getSexo>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        public async Task<IEnumerable<getTipoAtencion>> ListarTipoAtencion()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_TIPOATENCION";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getTipoAtencion>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getLugarAtencion>> ListarLugarAtencion()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_LUGARATENCION";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getLugarAtencion>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getCondicionMaterna>> ListarCondicionMaterna()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_CONDICIONMATERNA";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getCondicionMaterna>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getTipoDiagnostico>> ListarTipoDiagnostico()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_TIPODIAGNOSTICO";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getTipoDiagnostico>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getTipoModalidadAte>> ListarTipoModalidadAte(string V_TIPOMODALIDAD)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_TIPOMODALIDAD", V_TIPOMODALIDAD, OracleMappingType.Char, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.REC_ATE_MODALIDADATENCION_CONS";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getTipoModalidadAte>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getOrigenPersonal>> ListarOrigenPersonal(string V_CODIGO)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_CODIGO", V_CODIGO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.REC_ATE_ORIGENPERSONAL_CONSULT";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getOrigenPersonal>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<getTipoPersonal>> ListarTipoPersonal()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_TIPOPERSONAL";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<getTipoPersonal>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        public async Task<IEnumerable<getEspecialidad>> ListarEspecialidad()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_ESPEPROFESIONAL";

                var result = await SqlMapper.QueryAsync<getEspecialidad>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

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
