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
    }
}
