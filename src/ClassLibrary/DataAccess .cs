using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ClassLibrary.Models;
using LogicLayers.AppConfig;
using Oracle.ManagedDataAccess.Client;

namespace ClassLibrary
{
    public class DataAccess : IDataAccess
    {
        void IDataAccess.DeleteDataById(string id)
        {
            throw new NotImplementedException();
        }

        ReturnData IDataAccess.GetDataItemById(string id)
        {
            return ReadSqlData(id).FirstOrDefault();
        }

        IEnumerable<ReturnData> IDataAccess.GetDataList()
        {
            //Create a connection to Oracle			
            return ReadSqlData();
        }

        private static IEnumerable<ReturnData> ReadSqlData(string id = null)
        {
            string conString = AppConfiguration.SqlConnectionString;

            var retValue = new List<ReturnData>();

            using (var con = new SqlConnection(conString))
            {
                using (var cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        var sql = "SELECT TOP 10 [MSTR_SUP_ID] ,[CONT_NAME] ,[CONT_F_NAME] ,[CONT_L_NAME] ,[CONT_EMAIL] ,[CONT_STATUS] ,[LoadDate] FROM [CONTACTS]";
                       

                        if (id != null)
                        {
                            sql += $" Where [MSTR_SUP_ID] = '{id}'";
                        }
                        cmd.CommandText = sql;
                        //if (id != null)
                        //{
                        //    SqlParameter idParameter = new SqlParameter("id", id);
                        //    cmd.Parameters.Add(idParameter);
                        //}


                        //Execute the command and use DataReader to display the data
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                retValue.Add(new ReturnData { Id = reader[0].ToString() });
                            }
                        }

                        return retValue;
                    }
                    catch (OracleException oracleExceptionex)
                    {
                        throw oracleExceptionex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }



        public string ReadOracle()
        {
            //Create a connection to Oracle			
            string conString = AppConfiguration.OracleConnectionString;

            string retValue = null;

            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;
                        cmd.CommandText = "select * from Lax where rownum = :num";
                        OracleParameter num = new OracleParameter("num", 1);
                        cmd.Parameters.Add(num);

                        //Execute the command and use DataReader to display the data
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                retValue = reader[0].ToString();
                            }
                        }

                        return retValue;

                    }
                    catch (OracleException oracleExceptionex)
                    {
                        throw oracleExceptionex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }



}
