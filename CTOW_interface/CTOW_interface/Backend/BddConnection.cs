using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CTOW_interface.Backend
{
    class BddConnection
    {
        private SqlConnection connection;
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //Constructor
        public BddConnection()
        {
            builder.DataSource = "datommi-srv.database.windows.net";
            builder.UserID = "datommi";
            builder.Password = "CoW11235813";
            builder.InitialCatalog = "datommi-grp-resr";
            connection = new SqlConnection(builder.ConnectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
        public double GetMaxPollution()
        {
            double maxPollution = 0;
            SqlRequete newRequest = new SqlRequete();
            newRequest.MaxPollution();
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                maxPollution = Convert.ToDouble(dataReader["value_data"]);
                return maxPollution;
            }
            else
            {
                return maxPollution;
            }
        }
        public double GetMinPollution()
        {
            double minPollution = 0;
            SqlRequete newRequest = new SqlRequete();
            newRequest.MinPollution();
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                minPollution = Convert.ToDouble(dataReader["value_data"]);
                return minPollution;
            }
            else
            {
                return minPollution;
            }
        }
        public double GetMaxSonor()
        {
            double maxSensor = 0;
            SqlRequete newRequest = new SqlRequete();
            newRequest.MaxSonor();
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                maxSensor = Convert.ToDouble(dataReader["value_data"]);
                return maxSensor;
            }
            else
            {
                return maxSensor;
            }
        }
        public double GetMinSonor()
        {
            double minSensor = 0;
            SqlRequete newRequest = new SqlRequete();
            newRequest.MinSonor();
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                minSensor = Convert.ToDouble(dataReader["value_data"]);
                return minSensor;
            }
            else
            {
                return minSensor;
            }
        }
        public double GetMaxInternet()
        {
            double maxInternet = 0;
            SqlRequete newRequest = new SqlRequete();
            newRequest.MaxInternet();
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                maxInternet = Convert.ToDouble(dataReader["value_data"]);
                return maxInternet;
            }
            else
            {
                return maxInternet;
            }
        }
        public double GetMinInternet()
        {
            double minInternet = 0;
            SqlRequete newRequest = new SqlRequete();
            newRequest.MinInternet();
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                minInternet = Convert.ToDouble(dataReader["value_data"]);
                return minInternet;
            }
            else
            {
                return minInternet;
            }
        }
        public List<Data> GetDataDevice(int guid)
        {
            List<Data> data = new List<Data>();
            SqlRequete newRequest = new SqlRequete();
            newRequest.DataFromDevice(guid);
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                while (dataReader.Read())//while reading data => add on the list the data
                {
                    data.Add(new Data(Convert.ToDouble(dataReader["value_data"]), Convert.ToString(dataReader["type_data_description"]), Convert.ToDateTime(dataReader["data_time"])));
                }
                return data;
            }
            else
            {
                return null;
            }
        }
        public double GetAvgDataDevice(int guid)
        {
            double dataAvg = 0;
            SqlRequete newRequest = new SqlRequete();
            newRequest.AvgDataFromDevice(guid);
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                dataAvg = Convert.ToDouble(dataReader["value_data"]);
                return dataAvg;
            }
            else
            {
                return dataAvg;
            }
        }
        public List<Device> GetDevicesFromAdress(Adress adress)
        {
            List<Device> listDevices = new List<Device>();
            SqlRequete newRequest = new SqlRequete();
            newRequest.DeviceFromAdress(adress);
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                while (dataReader.Read())//while reading data => add on the list the data
                {
                    listDevices.Add(new Device(Convert.ToInt32(dataReader["iddevice"]), Convert.ToString(dataReader["device_description"])));
                }
                return listDevices;
            }
            else
            {
                return null;
            }
        }
        public List<Home> GetHome(double pollutionInt, double bruitIntensité, double vitesseInterent)
        {
            List<Home> listHome = new List<Home>();
            SqlRequete newRequest = new SqlRequete();
            newRequest.SelectAllHome();
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                List<Adress> listAdress = new List<Adress>();
                bool check = true;
                double data = 0;
                while (dataReader.Read())//while reading data => add on the list the data
                {
                    listAdress.Add(new Adress(Convert.ToString(dataReader["adress_number"]), Convert.ToString(dataReader["adress_street"]), Convert.ToInt32(dataReader["adress_cp"]), Convert.ToString(dataReader["adress_city"]), Convert.ToString(dataReader["adress_country"])));
                }
                foreach (Adress adress in listAdress)
                {
                    List<Device> deviceList = GetDevicesFromAdress(adress);
                    foreach (Device device in deviceList)
                    {
                        switch (device.DescriptionGet)
                        {
                            case "bruit":
                                data = GetAvgDataDevice(device.GuidGet);
                                if (data > bruitIntensité)
                                {
                                    check = false;
                                }
                                break;
                            case "pollution":
                                data = GetAvgDataDevice(device.GuidGet);
                                if (data > pollutionInt)
                                {
                                    check = false;
                                }
                                break;
                            case "internet":
                                data = GetAvgDataDevice(device.GuidGet);
                                if (data < vitesseInterent)
                                {
                                    check = false;
                                }
                                break;
                        }
                    }
                    if (check)
                    {
                        listHome.Add(new Home(adress, deviceList));
                    }
                }
            }
            return listHome;
        }
        public List<Data> GetDataFromMonth(string type)
        {
            List<Data> listData = new List<Data>();
            SqlRequete newRequest = new SqlRequete();
            switch(type)
            {
                case "AQ":
                    newRequest.SelectPollutionMonth();
                    break;
                case "INT":
                    newRequest.SelectInternetMonth();
                    break;
                case "SONOR":
                    newRequest.SelectSonorMonth();
                    break;
            }
            if (OpenConnection() == true)//try to connect on the database
            {
                SqlCommand cmd = new SqlCommand(newRequest.RequesteGet, connection);
                SqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                while (dataReader.Read())//while reading data => add on the list the data
                {
                    listData.Add(new Data(Convert.ToDouble(dataReader["value_data"]),Convert.ToString(dataReader["type_idtype"]),Convert.ToDateTime(dataReader["data_time"])));
                }
                return listData;
            }
            else
            {
                return null;
            }
        }
    }
}
