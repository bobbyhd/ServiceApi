using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Models;

namespace ClassLibrary
{
    public class DataAccessMock : IDataAccess
    {
        List<ReturnData> _list = new List<ReturnData>();

        IEnumerable<ReturnData> IDataAccess.GetDataList()
        {
            List<ReturnData> list = new List<ReturnData>();
            for (int i = 0; i < 10; i++)
            {
                var ret = new ReturnData
                {
                    Id = 0
                };
                list.Add(ret);
            }

            return list;
        }

        ReturnData IDataAccess.GetItemById(int id)
        {
            var retItem = _list.FirstOrDefault(x => x.Id == id);
            return retItem;
        }

        void IDataAccess.DeleteDataById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
