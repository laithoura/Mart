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
    public partial class USold : UserControl
    {
        private static USold _instance;

        public static USold Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new USold();
                return _instance;
            }
        }
        public USold()
        {
            InitializeComponent();
        }
    }
}
