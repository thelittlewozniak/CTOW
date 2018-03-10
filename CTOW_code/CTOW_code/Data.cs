using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTOW_code
{
    class Data
    {
        private double value;
        private string type;
        private DateTime dateTime;
        public double ValueGet { get=>value; }
        public string TypeGet { get=>type; }
        public DateTime DateTimeGet { get=>dateTime; }
        public Data(double value,string type,DateTime dateTime)
        {
            this.value = value;
            this.type = type;
            this.dateTime = dateTime;
        }
    }
}
