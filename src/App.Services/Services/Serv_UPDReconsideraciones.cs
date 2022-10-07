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

        public async Task<bool> Actualizar_FUA(getAtencionRecxID model)
        {
            try
            {
                var conn = new OracleConnection(_connectionString);
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("N_ATE_IDNUMREG", model.ATE_IDNUMREG, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_ATE_IDCOMPONENTE", model.ATE_IDCOMPONENTE, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_DISAAFIINS", model.ATE_DISAAFIINS, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_TIPOFORMATOAFIINS", model.ATE_TIPOFORMATOAFIINS, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_NUMREGAFIINS", model.ATE_NUMREGAFIINS, OracleMappingType.Varchar2, ParameterDirection.Input);

                dyParam.Add("V_ATE_TIPODOCUMENTO", model.ATE_TIPODOCUMENTO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_DNI", model.ATE_DNI, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_APPAT", model.ATE_APPAT, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_APMAT", model.ATE_APMAT, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_PNOM", model.ATE_PNOM, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_SNOM", model.ATE_SNOM, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("D_ATE_FECNAC", model.ATE_FECNAC, OracleMappingType.Date, ParameterDirection.Input);
                dyParam.Add("N_ATE_EDAD", model.ATE_EDAD, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_ATE_IDSEXO", model.ATE_IDSEXO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("N_ATE_IDMODALIDAD", model.ATE_IDMODALIDAD, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_ATE_ESGESTANTE", model.ATE_ESGESTANTE, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("D_ATE_FECPARTO", model.ATE_FECPARTO, OracleMappingType.Date, ParameterDirection.Input);
                dyParam.Add("V_ATE_HISTORIACLINICA", model.ATE_HISTORIACLINICA, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_NUMAUTORIZACION", model.ATE_NUMAUTORIZACION, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("N_ATE_MONTO", model.ATE_MONTO, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("D_ATE_FECATENCION", model.ATE_FECATENCION, OracleMappingType.Date, ParameterDirection.Input);
                dyParam.Add("V_ATE_IDLUGAR", model.ATE_IDLUGAR, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("N_ATE_IDORIGENPERSONAL", model.ATE_IDORIGENPERSONAL, OracleMappingType.Decimal, ParameterDirection.Input);

                dyParam.Add("V_ATE_IDSERVICIO", model.ATE_IDSERVICIO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_IDEESSREFIRIO", model.ATE_IDEESSREFIRIO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_NROHOJAREFERENCIA", model.ATE_NROHOJAREFERENCIA, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("D_ATE_FECINGHOSP", model.ATE_FECINGHOSP, OracleMappingType.Date, ParameterDirection.Input);
                dyParam.Add("V_ATE_CODDESTINO", model.ATE_CODDESTINO, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("D_ATE_FECALTAHOSP", model.ATE_FECALTAHOSP, OracleMappingType.Date, ParameterDirection.Input);
                dyParam.Add("V_ATE_IDEESSCONTRAREFIERE", model.ATE_IDEESSCONTRAREFIERE, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_NUMHOJACONTRAREFIERE", model.ATE_NUMHOJACONTRAREFIERE, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_TIPODOCPERSONALSALUD", model.ATE_TIPODOCPERSONALSALUD, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_DNIPERSONALSALUD", model.ATE_DNIPERSONALSALUD, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("V_ATE_COLEGIATURAPERSONALSALUD", model.ATE_COLEGIATURAPERSONALSALUD, OracleMappingType.Varchar2, ParameterDirection.Input);
                dyParam.Add("N_ATE_IDTIPOPERSONALSALUD", model.ATE_IDTIPOPERSONALSALUD, OracleMappingType.Decimal, ParameterDirection.Input);
                dyParam.Add("V_ATE_OBSERVACION", model.ATE_OBSERVACION, OracleMappingType.Varchar2, ParameterDirection.Input);

                var query = $"{_SchemaOracle.reconsideraciones}.PR_REC_UPD_IATENCION";
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
