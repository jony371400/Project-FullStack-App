using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Tutorial_dotNet3._1.Models;

namespace WebAPI_Tutorial_dotNet3._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        Test test;
        List<Test> testList = new List<Test>();
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {          
            _configuration = configuration;
            Init();
        }

        void Init()
        {
            for (int i = 1; i < 11; i++)
            {
                var id = i;
                var name = "Johnny" + i;

                test = new Test(id, name);
                testList.Add(test);
            }
        }

        #region GET: api/<TestController>
        [HttpGet]
        public List<Test> Get()
        {
            return testList;
        }
        #endregion

        #region Get api/<TestController>/Index
        [HttpGet("{id}")]
        public Test Get(int id)
        {
            return testList[id-1];
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