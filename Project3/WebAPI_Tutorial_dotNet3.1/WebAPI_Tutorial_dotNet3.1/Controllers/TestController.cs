using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using WebAPI_Tutorial_dotNet3._1.Models;
using WebAPI_Tutorial_dotNet3._1.DLL;

namespace WebAPI_Tutorial_dotNet3._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        Test test;
        List<Test> testList = new List<Test>();
        clsOracle _clsOracle = new clsOracle();
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            for (int i = 1; i< 11; i++)
            {
                var id = i;
                var name = "Johnny" + i;

                test = new Test(id, name);
                testList.Add(test);
            }

            _configuration = configuration;
        }

        #region GET: api/<TestController>
        //[HttpGet]
        //public List<Test> Get()
        //{
        //    return testList;
        //}

        [HttpGet]
        public string  Get()
        {
            string strConn = _configuration.GetSection("ConnectionStrings").GetSection("WYTN_SFCSP_FA").Value;
            string strSQL = _configuration.GetSection("ConnectionStrings").GetSection("SQL").Value;            

            DataTable response = new DataTable();
            string json = "";

            try
            {
                _clsOracle.Open(strConn);
                response = _clsOracle.ExecSQL(strSQL);
                json = JsonConvert.SerializeObject(response, Formatting.Indented);
                //response = JsonConvert.DeserializeObject<DataTable>(json);
            }
            catch (Exception ex)
            {
                var msg = ex.Message.ToString();
            }

            //return response;
            return json;
        }
        #endregion

        #region Get api/<TestController>/Index
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet("{usn}")]
        public string Get(string usn)
        {
            string strConn = _configuration.GetSection("ConnectionStrings").GetSection("WYTN_SFCSP_FA").Value;
            string strSQL = _configuration.GetSection("ConnectionStrings").GetSection("SQL").Value;
            DataTable response = new DataTable();
            string json = "";

            try
            {
                _clsOracle.Open(strConn);
                response = _clsOracle.ExecSQL(strSQL + " where usn in ('" + usn + "')");
                json = JsonConvert.SerializeObject(response, Formatting.Indented);
                //response = JsonConvert.DeserializeObject<DataTable>(json);
            }
            catch (Exception ex)
            {
                var msg = ex.Message.ToString();
            }

            return json;
        }
        #endregion

        #region POST api/<TestController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //    //testlist.add(value);
        //    var s = value;
        //}

        [HttpPost]
        public string Post(string value)
        {
            var s = value;
            return s;
        }
        #endregion

        #region PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        #endregion

        #region  DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}