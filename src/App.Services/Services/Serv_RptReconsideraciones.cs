using App.Services.IServices;
using App.ViewModels;
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
using App.ViewModels.RptReconsideraciones;

namespace App.Services.Services
{
    public class Serv_RptReconsideraciones : IRptReconsideraciones
    {
        private readonly string _connectionString;
        private readonly SchemaOracle _SchemaOracle;

        public Serv_RptReconsideraciones(IConfiguration configuration, IOptions<SchemaOracle> schemaOracle)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _SchemaOracle = schemaOracle.Value;
        }

        //public async Task<IEnumerable<GetRptAtenciones>> RptAtenciones(SetRptAtenciones model)
        //{
        //    try
        //    {

        //        var conn = new OracleConnection(_connectionString);
        //        var dyParam = new OracleDynamicParameters();
        //        dyParam.Add("P_V_PERIODO", model.P_V_PERIODO, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //        dyParam.Add("P_V_MES", model.P_V_MES, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //        dyParam.Add("P_V_DISA", model.P_V_DISA, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //        dyParam.Add("P_V_UEJEC", model.P_V_UEJEC, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //        dyParam.Add("P_V_ESTABLECIMIENTO", model.P_V_ESTABLECIMIENTO, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //        dyParam.Add("P_V_ESTADO", model.P_V_ESTADO, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //        dyParam.Add("P_V_TIPO", model.P_V_TIPO, OracleMappingType.NVarchar2, ParameterDirection.Input);


        //        dyParam.Add("CV_1", string.Empty, OracleMappingType.RefCursor, ParameterDirection.Output);

        //        var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_RPTRECATENCION";
        //        //conn.Execute(query, dyParam, commandType: CommandType.StoredProcedure);

        //        var result = await SqlMapper.QueryAsync<GetRptAtenciones>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //        throw ex;
        //    }
        //}



       public async Task<DataTable> RptAtenciones(SetRptAtenciones model)
        {
            string query = $"{_SchemaOracle.reconsideraciones}.PR_REC_RPTRECATENCION";
            DataTable tabla = new DataTable();

            try
            {
                var cn = new OracleConnection(_connectionString);
                await cn.OpenAsync();
                using (OracleDataAdapter da = new OracleDataAdapter(query, cn))
                {
                    da.SelectCommand.Parameters.Add("P_V_PERIODO", OracleDbType.Varchar2, 255).Value = model.P_V_PERIODO;
                    da.SelectCommand.Parameters.Add("P_V_MES", OracleDbType.Varchar2, 255).Value = model.P_V_MES;
                    da.SelectCommand.Parameters.Add("P_V_DISA", OracleDbType.Varchar2, 255).Value = model.P_V_DISA;
                    da.SelectCommand.Parameters.Add("P_V_UEJEC", OracleDbType.Varchar2, 255).Value = model.P_V_UEJEC;
                    da.SelectCommand.Parameters.Add("P_V_ESTABLECIMIENTO", OracleDbType.Varchar2, 255).Value = model.P_V_ESTABLECIMIENTO;
                    da.SelectCommand.Parameters.Add("P_V_ESTADO", OracleDbType.Varchar2, 255).Value = model.P_V_ESTADO;
                    da.SelectCommand.Parameters.Add("P_V_TIPO", OracleDbType.Varchar2, 255).Value = model.P_V_TIPO;

                    da.SelectCommand.Parameters.Add("CV_1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    //da.SelectCommand.Parameters["CV_1"].Direction = ParameterDirection.Output;

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return tabla;
        }
    }
}
