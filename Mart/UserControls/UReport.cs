using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mart
{
    public partial class UReport : UserControl
    {
        private static UReport _instance;

        public static UReport Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UReport();
                return _instance;
            }
        }
        public UReport()
        {
            InitializeComponent();
        }
    }
}
