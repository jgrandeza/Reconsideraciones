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
    public class RecSolicitud: IReadSolicitudRecon
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;

        public RecSolicitud(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }

        public async Task<IEnumerable<GetPeriodosDISAEESS>> GetPeriodosDISAEESS(SetPeriodosDISAEESS model)
        {              
                try
                {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_TIPO_CONSULTA", model.V_TIPO_CONSULTA, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_DISA", model.V_DISA, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_EESS", model.V_EESS, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);


                var query = "RECONSIDERACIONES.REC_PERIODOS_DISAEESS";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetPeriodosDISAEESS>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        public async Task<GetRangoPeriodoRec> GetRangoPeriodoRec(SetRangoPeriodoRec model)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_PERIODO", model.V_PERIODO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);


                var query = "RECONSIDERACIONES.REC_MOSTRAR_RANGOPERIODO_REC";

                var result = await SqlMapper.QueryAsync<GetRangoPeriodoRec>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result.First();
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<GetPeriodoProdAtc>> GetPeriodoProcAtc(SetRangoPeriodoRec model)
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("V_PERIODO", model.V_PERIODO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);


                var query = $"{_SchemaOracle.reconsideraciones}.REC_PERIODO_PROD_ATEN";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetPeriodoProdAtc>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<GetFiltros>> GetTipoTarifario()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_TIPOTARIFARIO";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetFiltros>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<GetFiltros>> GetTipoObservacion()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_TIPOOBSERVACION";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetFiltros>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<IEnumerable<GetFiltros>> GetEstadoReconsideracion()
        {
            try
            {

                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_SEL_ESTADOREC";
                //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<GetFiltros>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

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
