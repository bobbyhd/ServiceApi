using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetOracleController : ControllerBase
    {
        // GET: api/GetOracleData
        [HttpGet("{subTypeId}")]
        public IEnumerable<OracleData> Get(string subTypeId)
        {
            IDataAccess da = new DataAccess();
            var retList = da.ReadOracle(subTypeId);

            return retList;
        }


        // POST: api/GetOracleData
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/GetOracleData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
