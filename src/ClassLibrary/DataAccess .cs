using System;
using System.Collections.Generic;
using ClassLibrary.Models;

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
    }
}
