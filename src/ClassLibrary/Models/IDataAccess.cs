using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public interface IDataAccess
    {
        IEnumerable<ReturnData> GetDataList();
        void DeleteDataById(string id);
        ReturnData GetDataItemById(string id);

        string ReadOracle();

    }
}
