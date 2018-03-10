using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTOW_interface
{
    class Home
    {
        private Adress homeAdress; //adress of home
        private List<Device> homeDevices; //list of devices
        public Adress HomeAdressGet { get => homeAdress; }
        public List<Device> HomeDeviceGet { get => homeDevices; }
        public Home(Adress homeAdress, List<Device> homeDevices)
        {
            this.homeAdress = homeAdress;
            this.homeDevices = homeDevices;
        }
    }
}
