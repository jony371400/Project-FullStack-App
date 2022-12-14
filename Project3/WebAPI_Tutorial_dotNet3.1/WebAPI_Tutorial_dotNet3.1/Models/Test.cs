using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Tutorial_dotNet3._1.Models
{
    public class Test
    {
        public Test(int Id , string Name)
        {
            TestID = Id;
            TestName = Name;
        }

        public int TestID { get; set; }

        public string TestName { get; set; }
    }
}
