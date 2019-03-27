using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Models;

namespace ClassLibrary
{
    public class DataAccessMock : IDataAccess
    {


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

        ReturnData IDataAccess.GetDataItemById(int id)
        {
            var list = ((IDataAccess) this).GetDataList();
            var retItem = list.FirstOrDefault(x => x.Id == id);
            return retItem;
        }

        void IDataAccess.DeleteDataById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
