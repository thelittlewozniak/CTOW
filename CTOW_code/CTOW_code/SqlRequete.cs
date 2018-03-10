using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTOW_code
{
    class SqlRequete
    {
        private string request;
        public string RequesteGet { get;}
        public SqlRequete()
        {

        }
        public void MaxPollution() //requeste to have the max of the pollution saved
        {
            request = "SELCT max(value_data) FROM data where type_idtype=AQ";
        }
        public void MinPollution() //requeste to have the max of the pollution saved
        {
            request = "SELCT min(value_data) FROM data where type_idtype=AQ";
        }
        public void MaxSonor()
        {
            request = "SELECT max(value_data) FROM data where type_idtype=SONOR";
        }
        public void MinSonor()
        {
            request = "SELECT min(value_data) FROM data where type_idtype=SONOR";
        }
        public void MaxInternet()
        {
            request = "SELECT max(value_data) FROM data where type_idtype=INT";
        }
        public void MinInternet()
        {
            request = "SELECT min(value_data) FROM data where type_idtype=INT";
        }
        public void DataFromDevice(int guid)
        {
            request = "SELECT value_data,data_time,type_data_description FROM data INNER JOIN type_data on data.type_idtype_data=type_data.idtype_data where device_iddevice=" + guid;
        }
        public void AvgDataFromDevice(int guid)
        {
            request = "SELECT avg(value_data) FROM data group by device_iddevice where device_iddevice=" + guid;
        }
        public void DeviceFromAdress(Adress adress)
        {
            string city = adress.CityGet;
            string country = adress.CountryGet;
            int cp = adress.CpGet;
            string street = adress.StreetGet;
            string number = adress.NumberGet;
            request = String.Concat("SELECT * FROM device INNER JOIN adress ON adress.idadresse=device.adress_idadresse where adress_street="+street+" and adress_number="+number+" and adress_cp="+cp+" and adress_city="+city+" and adress_country="+country);
        }
    }
}
