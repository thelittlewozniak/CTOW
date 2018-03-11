using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTOW_interface.Backend;
using OxyPlot;

namespace CTOW_interface
{
	public class MainViewModel
	{
		public MainViewModel ()
		{
            BddConnection bddConnection = new BddConnection();
            this.Pol = "Pollution";
            this.PtPol = new List<DataPoint>();
            int i = 0;
            foreach (Data data in bddConnection.GetDataFromMonth("AQ"))
            {
                this.PtPol.Add(new DataPoint(i, data.ValueGet));
                i++;
            }
            this.Bruit = "Bruit";
            this.PtBruit = new List<DataPoint>();
            int j = 0;
            foreach (Data data in bddConnection.GetDataFromMonth("SONOR"))
            {
                this.PtBruit.Add(new DataPoint(j, data.ValueGet));
                j++;
            }
            this.Debit = "Débit Internet";
            this.PtDebit = new List<DataPoint>();
            int g = 0;
            foreach (Data data in bddConnection.GetDataFromMonth("SONOR"))
            {
                this.PtBruit.Add(new DataPoint(j, data.ValueGet));
                g++;
            }
            this.Detail = "Détail";
            this.PtDetail = new List<DataPoint>
                              {
                                  new DataPoint(0, 6),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };
        }
        public string Pol { get; private set; }

        public IList<DataPoint> PtPol { get; private set; }
        public string Bruit { get; private set; }

        public IList<DataPoint> PtBruit { get; private set; }
        public string Debit { get; private set; }

        public IList<DataPoint> PtDebit { get; private set; }
        public string Detail { get; private set; }

        public IList<DataPoint> PtDetail { get; private set; }
    }
}