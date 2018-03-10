using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTOW_code
{
    class Device
    {
        private int guid; //the unique ID of the device
        private string description; //what's do the device
        private List<Data> deviceData; //the data from the device
        public int GuidGet { get=>guid;}
        public string DescriptionGet { get=>description;}
        
        public Device(int guid,string description)
        {
            this.guid = guid;
            this.description = description;
        }
    }
}
