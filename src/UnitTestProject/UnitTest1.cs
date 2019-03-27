using System;
using System.Linq;
using ClassLibrary;
using ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetListOfData()
        {
            IDataAccess da = new DataAccessMock();
            var retList = da.GetDataList().ToList();

            Assert.IsTrue(retList.Any());

        }

        [TestMethod]
        public void GetDataById()
        {
            IDataAccess da = new DataAccessMock();
            var retList = da.GetDataItemById(0);

            Assert.IsNotNull(retList);
        }

    }
}
