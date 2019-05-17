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
    public class GLNReportController : ControllerBase
    {
        // GET: api/GLNReport
        [HttpGet("{subTypeId}")]
        public IEnumerable<OracleData> Get(string subTypeId)
        {
            IDataAccess da = new DataAccess();
            var retList = da.ReadOracle(subTypeId);

            return retList;
        }


        // POST: api/GLNReport
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/GLNReport/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/GLNReport/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
