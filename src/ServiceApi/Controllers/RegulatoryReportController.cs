using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace ServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegulatoryReportController : ControllerBase
    {
        // GET api/RegulatoryReport
        [HttpGet]
        public ActionResult<IEnumerable<ReturnData>> Get()
        {
            IDataAccess da = new DataAccess();
            var retList = da.GetDataList().ToList();
            return retList;
        }

        // GET api/RegulatoryReport/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<ReturnData> Get(string id)
        {
            IDataAccess da = new DataAccess();
            var retList = da.GetDataItemById(id);
            return retList;
        }

        // POST api/RegulatoryReport
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/RegulatoryReport/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value)
        {
        }

        // DELETE api/RegulatoryReport/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
