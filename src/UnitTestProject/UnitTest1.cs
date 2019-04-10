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
            IDataAccess da = new DataAccess();
            var retList = da.GetDataItemById("Vendor-000000016");

            Assert.IsNotNull(retList);
        }

        [TestMethod]
        public void GetSqlData()
        {
            IDataAccess da = new DataAccess();
            var retList = da.GetDataList();

            Assert.IsNotNull(retList);
        }
        [TestMethod]
        public void GetOracleData()
        {
            IDataAccess da = new DataAccess();
            var retList = da.ReadOracle();

            Assert.IsNotNull(retList);
        }

    }
}
