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
    public partial class UBin : UserControl
    {
        private static UBin _instance;

        public static UBin Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UBin();
                return _instance;
            }
        }
        public UBin()
        {
            InitializeComponent();
        }
    }
}
