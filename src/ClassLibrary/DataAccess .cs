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
            string conString =
                //"Data Source=151.140.50.123;Initial Catalog=HDLINK;Integrated Security=True"; //  AppConfiguration.SqlConnectionString;
                "Data Source=151.140.50.123;Initial Catalog=HDLINK;pwd=nED6S7tM8Idj; user ID=QCSQLReporting"; //  AppConfiguration.SqlConnectionString;
            var retValue = new List<ReturnData>();
            try
            {
                using (var con = new SqlConnection(conString))
                {
                    using (var cmd = con.CreateCommand())
                    {

                        con.Open();
                        var sql =
                            "SELECT TOP 10 [MSTR_SUP_ID] ,[CONT_NAME] ,[CONT_F_NAME] ,[CONT_L_NAME] ,[CONT_EMAIL] ,[CONT_STATUS] ,[LoadDate] FROM [CONTACTS]";

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
                    }
                }
            }
            catch (SqlException sqlException)
            {
                retValue.Add(new ReturnData
                {
                    Id = $"Data Exception: {sqlException.Message}"
                });
            }
            catch (Exception ex)
            {
                retValue.Add(new ReturnData
                {
                    Id = $"Data Exception: {ex.Message}"
                });
            }
            return retValue;
        }

        public List<OracleData> ReadOracle(string subTypeId)
        {
            //Create a connection to Oracle			
            string conString =
                "User Id=Stepview;Password=nopride2012;Data Source=spragor23-scan:1521/DPR23MMS_SRO01;Connection Timeout=600";// AppConfiguration.OracleConnectionString;

            conString =
                    "Data Source=snpagor24-scan:1521/dqp026mm_srw01; User Id=stepview; Password=stepview;";

            List<OracleData> retValue = new List<OracleData>();
            try
            {
                using (OracleConnection con = new OracleConnection(conString))
                {
                    con.Open();
                    OracleCommand cmd1 = con.CreateCommand();
                    cmd1.BindByName = true;
                    cmd1.CommandText = "begin stepview.pimviewapipck.setviewcontext('EN US All', 'Main'); end;";
                    cmd1.ExecuteNonQuery();

                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        var sql = "select c3.name as VendorID, " +
                                  "pimviewapipck.getcontextname(c3.id, 5976913, 200) AS VendorName, " +
                                  "c2.name as GLN " +
                                  "from classification_v c1 " +
                                  "left join link_v l1 ON c1.id = l1.childid " +
                                  "inner join classification_v c2 ON l1.parentid = c2.id " +
                                  "inner join link_v l2 ON c2.id = l2.childid " +
                                  "inner join classification_v c3 ON l2.parentid = c3.id " +
                                  $"where c1.subtypeid = '{subTypeId}'";

                        cmd.BindByName = true;
                        cmd.CommandText = sql;

                        OracleParameter num = new OracleParameter("id", "743347989");
                        //cmd.Parameters.Add(num);

                        //Execute the command and use DataReader to display the data 
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                retValue.Add(new OracleData
                                {
                                    VendorID = reader["VendorID"].ToString(),
                                    VendorName = reader["VendorName"].ToString(),
                                    GLN = reader["GLN"].ToString()
                                });
                            }
                        }

                        //return retValue;
                    }
                }
            }
            catch (OracleException oracleExceptionex)
            {
                var oracleError = new OracleData
                {
                    GLN = "-",
                    VendorID = "Data Exception",
                    VendorName = oracleExceptionex.Message
                };
                retValue.Add(oracleError);
            }
            catch (Exception ex)
            {
                var oracleError = new OracleData
                {
                    GLN = "-",
                    VendorID = "General Exception",
                    VendorName = ex.Message
                };
                retValue.Add(oracleError);

            }
            return retValue;
        }
    }



}
