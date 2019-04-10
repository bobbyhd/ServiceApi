using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public interface IDataAccess
    {
        IEnumerable<ReturnData> GetDataList();
        void DeleteDataById(int id);
        ReturnData GetDataItemById(int id);

        string ReadOracle();

    }
}
