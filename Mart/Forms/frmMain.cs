using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mart.UserControls;

namespace Mart
{
    public partial class frmMain : Form
    {
        List<Panel> listPanel = new List<Panel>();      
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(UUser.Instance))
            {
                mainPanel.Controls.Add(UUser.Instance);
                UUser.Instance.Dock = DockStyle.Fill;
                UUser.Instance.BringToFront();
            }
            else
            {
                UUser.Instance.BringToFront();
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(USetting.Instance))
            {
                mainPanel.Controls.Add(USetting.Instance);
                USetting.Instance.Dock = DockStyle.Fill;
                USetting.Instance.BringToFront();
            }
            else
            {
                USetting.Instance.BringToFront();
            }
        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(UBin.Instance))
            {
                mainPanel.Controls.Add(UBin.Instance);
                UBin.Instance.Dock = DockStyle.Fill;
                UBin.Instance.BringToFront();
            }
            else
            {
                UBin.Instance.BringToFront();
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(UProduct.Instance))
            {
                mainPanel.Controls.Add(UProduct.Instance);
                UProduct.Instance.Dock = DockStyle.Fill;
                UProduct.Instance.BringToFront();
            }
            else
            {
                UProduct.Instance.BringToFront();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(UReport.Instance))
            {
                mainPanel.Controls.Add(UReport.Instance);
                UReport.Instance.Dock = DockStyle.Fill;
                UReport.Instance.BringToFront();
            }
            else
            {
                UReport.Instance.BringToFront();
            }
        }

        private void btnSold_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(USold.Instance))
            {
                mainPanel.Controls.Add(USold.Instance);
                USold.Instance.Dock = DockStyle.Fill;
                USold.Instance.BringToFront();
            }
            else
            {
                USold.Instance.BringToFront();
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(UImportStock.Instance))
            {
                mainPanel.Controls.Add(UImportStock.Instance);
                UImportStock.Instance.Dock = DockStyle.Fill;
                UImportStock.Instance.BringToFront();
            }
            else
            {
                UImportStock.Instance.BringToFront();
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void showFormInPanel(Form form)
        {
            mainPanel.Controls.Clear();
            form.TopLevel = false;
            form.AutoScroll = true;
            mainPanel.Controls.Add(form);

            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
    }
}
