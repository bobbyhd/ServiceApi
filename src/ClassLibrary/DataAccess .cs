using System;
using System.Collections.Generic;
using ClassLibrary.Models;
using LogicLayers.AppConfig;
using Oracle.ManagedDataAccess.Client;

namespace ClassLibrary
{
    public class DataAccess : IDataAccess
    {
        void IDataAccess.DeleteDataById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ReturnData> IDataAccess.GetDataList()
        {
            throw new NotImplementedException();
        }

        ReturnData IDataAccess.GetDataItemById(int id)
        {
            throw new NotImplementedException();
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
