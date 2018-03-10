﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CTOW_code
{
    class BddConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public BddConnection()
        {
            Initialize(); //Call the inilialization of the connection
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost"; //we are in local for the moment
            database = "CTOW";
            uid = "admin";
            password = "azetty1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //if errors, we detect wich error is and inform the users.
                switch (ex.Number)
                {
                    case 0: //0 is cannot connect to the database
                        Error newError = new Error();
                        newError.LabelErrorContent.Content = "Cannot connect to server. Contact Administrator";
                        newError.Show();
                        break;

                    case 1045: // invalid username/password
                        Error newError1 = new Error();
                        newError1.LabelErrorContent.Content = "Invalid username/password, please try again";
                        newError1.Show();
                        break;
                }
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
            catch (MySqlException ex)
            {
                Error newError = new Error();
                newError.LabelErrorContent.Content = ex.Message;
                newError.Show();
                return false;
            }
        }
        public double GetMaxPollution()
        {
            double maxPollution=0;
            OpenConnection(); //Open the connection with the database
            SqlRequete newRequest = new SqlRequete();
            newRequest.MaxPollution();
            if(OpenConnection()==true)//try to connect on the database
            {
                MySqlCommand cmd = new MySqlCommand(newRequest.RequesteGet, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
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
            OpenConnection(); //Open the connection with the database
            SqlRequete newRequest = new SqlRequete();
            newRequest.MinPollution();
            if (OpenConnection() == true)//try to connect on the database
            {
                MySqlCommand cmd = new MySqlCommand(newRequest.RequesteGet, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader(); //execute the request and take the max of the pollution
                minPollution = Convert.ToDouble(dataReader["value_data"]);
                return minPollution;
            }
            else
            {
                return minPollution;
            }
        }
    }
}
