using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using SIGACUtilitarios.DTO;

namespace SIGACUtilitarios.StoredProcedures

{
    public class DBCommon
    {
        // METODO PARA CONSUMIR EL SP QUE TRAE TODOS LOS PICKLIST MASTER Y PICKLIST ESPECIFICOS
        private string _connectionString;
        public DBCommon()
        {


        }

        //metodo generico para crear un registro de log error dependiendo el tipo
        public async Task<bool> GetGuardar(string NameCommand, Dictionary<string, int?> parametros, Dictionary<string, string> parametros2)
        {
            this._connectionString = MiConfigDTO.connnectionString;
            using (OracleConnection oracle = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand(NameCommand, oracle))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ESQUEMA", OracleDbType.Int64, parametros.ElementAt(0).Value, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_NOMBRESERVICIO", OracleDbType.Varchar2, parametros2.ElementAt(0).Value, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_PARAMETRO", OracleDbType.Varchar2, parametros2.ElementAt(1).Value, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_MENSAJE", OracleDbType.Varchar2, parametros2.ElementAt(2).Value, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_SEGUIMIENTOPILA", OracleDbType.Varchar2, parametros2.ElementAt(3).Value, ParameterDirection.Input));

                    bool response = false;
                    oracle.Open();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {


                        response = true;

                    }
                    return response;
                }
            }
        }

        public async Task<List<T>> SPGenericoCommand<T>(string NameCommand, string connectionString) where T : class, new()
        {
            this._connectionString = connectionString;
            using (OracleConnection oracle = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand(NameCommand, oracle))
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                   
                    var response = new List<T>();
                    oracle.Open();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            response.Add(Mapping<T>(reader).Result);
                        }
                    }
                    return response;
                }
            }
        }

        public async Task<List<T>> SPGenerico<T>(string NameCommand, ParamsSPDTO parametros, string connectionString) where T : class, new()
        {
            this._connectionString = connectionString;
            using (OracleConnection oracle = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand(NameCommand, oracle))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    for (int i = 0; i < parametros.parametrosString.Count; i++)
                    {
                        cmd.Parameters.Add(new OracleParameter(parametros.parametrosString.ElementAt(i).Key, OracleDbType.Varchar2, parametros.parametrosString.ElementAt(i).Value, ParameterDirection.Input));


                    }
                    for (int i = 0; i < parametros.parametrosInt.Count; i++)
                    {
                        cmd.Parameters.Add(new OracleParameter(parametros.parametrosInt.ElementAt(i).Key, OracleDbType.Int64, parametros.parametrosInt.ElementAt(i).Value, ParameterDirection.Input));
                    }

                    for (int i = 0; i < parametros.parametrosIntNull.Count; i++)
                    {
                        cmd.Parameters.Add(new OracleParameter(parametros.parametrosIntNull.ElementAt(i).Key, OracleDbType.Int64, parametros.parametrosIntNull.ElementAt(i).Value, ParameterDirection.Input));
                    }

                    for (int i = 0; i < parametros.parametrosDecimal.Count; i++)
                    {
                        cmd.Parameters.Add(new OracleParameter(parametros.parametrosDecimal.ElementAt(i).Key, OracleDbType.Decimal, parametros.parametrosDecimal.ElementAt(i).Value, ParameterDirection.Input));
                    }

                    for (int i = 0; i < parametros.parametrosDecimalNull.Count; i++)
                    {
                        cmd.Parameters.Add(new OracleParameter(parametros.parametrosDecimalNull.ElementAt(i).Key, OracleDbType.Decimal, parametros.parametrosDecimalNull.ElementAt(i).Value, ParameterDirection.Input));
                    }
                    for (int i = 0; i < parametros.parametrosDate.Count; i++)

                    {
                        cmd.Parameters.Add(new OracleParameter(parametros.parametrosDate.ElementAt(i).Key, OracleDbType.Date, parametros.parametrosDate.ElementAt(i).Value, ParameterDirection.Input));
                    }
                    for (int i = 0; i < parametros.parametrosDateNull.Count; i++)
                    {
                        cmd.Parameters.Add(new OracleParameter(parametros.parametrosDateNull.ElementAt(i).Key, OracleDbType.Date, parametros.parametrosDateNull.ElementAt(i).Value, ParameterDirection.Input));
                    }

                    if (parametros.cursor != "" && parametros.cursor != null)
                    {
                        cmd.Parameters.Add(new OracleParameter(parametros.cursor, OracleDbType.RefCursor, null, ParameterDirection.Output));
                    }

                    var response = new List<T>();
                    oracle.Open();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            response.Add(Mapping<T>(reader).Result);
                        }
                    }
                    return response;
                }
            }
        }





        private async Task<T> Mapping<T>(DbDataReader reader) where T : new()
        {
            var objeto = new T();
            Type tipo = objeto.GetType();
            var properties = tipo.GetProperties();



            for (int i = 0; i < tipo.GetProperties().Length; i++)
            {

                var nombre = tipo.GetProperties()[i].Name;
                object[] attrs = properties[i].GetCustomAttributes(false);
                var flag = false;
                foreach (object attr in attrs)
                {
                    Read read = attr as Read;
                    if (read != null)
                    {
                        if (!read.value)
                        {
                            flag = !flag;
                            continue;
                        }

                    }
                }
                if (flag)
                    continue;


                if (properties[i].PropertyType.Equals(typeof(int)))
                {
                    var valor = 0;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = (int)reader[nombre];
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }

                if (properties[i].PropertyType.Equals(typeof(int?)))
                {
                    int? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = (int)reader[nombre];
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(float)))
                {
                    var valor = 0.0f;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = Single.Parse(reader[nombre].ToString());
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(float?)))
                {
                    float? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = Single.Parse(reader[nombre].ToString());
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(string)))
                {
                    var valor = reader[nombre];
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        if (String.IsNullOrEmpty(valor.ToString()))
                            valor = "";
                        objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                    }

                }
                if (properties[i].PropertyType.Equals(typeof(bool?)))
                {
                    var valor = (bool?)reader[nombre];
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(bool)))
                {
                    bool? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (bool)reader[nombre];

                    }
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(DateTime)))
                {
                    DateTime? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (DateTime)reader[nombre];

                    }
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(DateTime?)))
                {
                    DateTime? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (DateTime?)reader[nombre];

                    }
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }



                if (properties[i].PropertyType.Equals(typeof(Decimal)))
                {
                    decimal? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (Decimal)reader[nombre];
                    }
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }

                if (properties[i].PropertyType.Equals(typeof(Decimal?)))
                {
                    decimal? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (Decimal?)reader[nombre];

                    }
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }

                if (properties[i].PropertyType.Equals(typeof(Double)))
                {
                    double? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (Double)reader[nombre];
                    }
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }

                if (properties[i].PropertyType.Equals(typeof(Double?)))
                {
                    double? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (Double?)reader[nombre];

                    }
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }

                if (properties[i].PropertyType.Equals(typeof(Int64)))
                {

                    Int64? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (Int64)reader[nombre];
                    }

                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(Int64?)))
                {

                    Int64? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (Int64?)reader[nombre];
                    }
                    try
                    {
                        if ((Int64)reader[nombre] == 0)
                        {

                            valor = 0;
                        }
                    }
                    catch (Exception e )
                    {

                       Console.WriteLine("Metodo SIGACUTILITARIOS.Email.cs.Mapping() excepcion controlada cuando un valor del sp es DBNull pero no es 0 ");
                    }
                    
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }

                if (properties[i].PropertyType.Equals(typeof(Byte[])))
                {
                    Byte[]? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (Byte[])reader[nombre];
                    }
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }

                if (properties[i].PropertyType.Equals(typeof(Byte?[])))
                {
                    Byte[]? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                    {
                        valor = (Byte[]?)reader[nombre];

                    }
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
            }
            return objeto;
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    public class Read : System.Attribute
    {
        public bool value;
        public Read(bool value)
        {
            this.value = value;
        }
    }
}
