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
    public partial class UProduct : UserControl
    {
        private static UProduct _instance;

        public static UProduct Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UProduct();
                return _instance;
            }
        }
        public UProduct()
        {
            InitializeComponent();
        }
    }
}
