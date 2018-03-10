using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OxyPlot;

namespace CTOW_interface
{
	public class MainViewModel
	{
		public MainViewModel ()
		{
            this.Pol = "Pollution";
            this.PtPol = new List<DataPoint>
                              {
                                  new DataPoint(0, 6),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };
            this.Bruit = "Bruit";
            this.PtBruit = new List<DataPoint>
                              {
                                  new DataPoint(0, 6),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };
            this.Debit = "Débit Internet";
            this.PtDebit = new List<DataPoint>
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
    }
}