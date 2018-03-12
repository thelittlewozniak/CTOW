using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTOW_interface.Backend
{
    class SqlRequete
    {
        private string request;
        public string RequesteGet { get; }
        public SqlRequete()
        {

        }
        public void MaxPollution() //requeste to have the max of the pollution saved
        {
            request = "SELCT max(value_data) FROM data where type_idtype_data='AQ'";
        }
        public void MinPollution() //requeste to have the max of the pollution saved
        {
            request = "SELCT min(value_data) FROM data where type_idtype_data='AQ'";
        }
        public void MaxSonor()
        {
            request = "SELECT max(value_data) FROM data where type_idtype_data='SONOR'";
        }
        public void MinSonor()
        {
            request = "SELECT min(value_data) FROM data where type_idtype_data='SONOR'";
        }
        public void MaxInternet()
        {
            request = "SELECT max(value_data) FROM data where type_idtype_data='INT'";
        }
        public void MinInternet()
        {
            request = "SELECT min(value_data) FROM data where type_idtype_data='INT'";
        }
        public void DataFromDevice(int guid)
        {
            request = "SELECT value_data,date,time,type_data_description FROM data INNER JOIN type_data on data.type_idtype_data=type_data.idtype_data where device_iddevice=" + guid;
        }
        public void AvgDataFromDevice(int guid)
        {
            request = "SELECT avg(value_data) FROM data where device_iddevice=" + guid+ "group by device_iddevice";
        }
        public void DeviceFromAdress(Adress adress)
        {
            string city = adress.CityGet;
            string country = adress.CountryGet;
            int cp = adress.CpGet;
            string street = adress.StreetGet;
            string number = adress.NumberGet;
            request = String.Concat("SELECT * FROM device INNER JOIN address ON adress.idaddresse=device.address_idaddress where address_street=" + street + " and address_number=" + number + " and address_cp=" + cp + " and address_city=" + city + " and address_country=" + country);
        }
        public void SelectAllHome()
        {
            request = "SELECT * FROM address";
        }
        public void SelectPollutionMonth()
        {
            request = "SELECT * FROM data INNER JOIN device ON data.device_iddevice=device.iddevice where type_idtype=AQ group by date order by date LIMIT 30";
        }
        public void SelectSonorMonth()
        {
            request = "SELECT * FROM data INNER JOIN device ON data.device_iddevice=device.iddevice where type_idtype=SONOR group by date order by date LIMIT 30";
        }
        public void SelectInternetMonth()
        {
            request = "SELECT avg(value_data) FROM data INNER JOIN device ON data.device_iddevice=device.iddevice where type_idtype=INT group by date order by date LIMIT 30";
        }
    }
}
