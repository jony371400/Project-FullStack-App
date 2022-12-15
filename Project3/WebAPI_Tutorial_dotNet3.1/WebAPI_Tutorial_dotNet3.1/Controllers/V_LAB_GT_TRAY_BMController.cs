using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using WebAPI_Tutorial_dotNet3._1.DLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Tutorial_dotNet3._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_LAB_GT_TRAY_BMController : ControllerBase
    {
        clsOracle _clsOracle = new clsOracle();
        private readonly IConfiguration _configuration;

        public V_LAB_GT_TRAY_BMController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        // GET: api/<V_LAB_GT_TRAY_BMController>
        [HttpGet]
        public string Get()
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

        #region POST api/<V_LAB_GT_TRAY_BMController>
        //[HttpPost]
        //public string Post(string value)
        //{
        //    return "Success";
        //}

        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "Success";
        }
        #endregion

        #region PUT api/<V_LAB_GT_TRAY_BMController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        #endregion

        #region DELETE api/<V_LAB_GT_TRAY_BMController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}