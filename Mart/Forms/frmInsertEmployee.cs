using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mart.Forms
{
    public partial class frmInsertEmployee : Form
    {
        SqlConnection con = Connection.getConnection();
        SqlDataReader dr = null;
        SqlCommand cmd = null;

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        public frmInsertEmployee()
        {
            InitializeComponent();

            RegisterEventMove();
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;     

            try
            {
                con.Open();
                cmd = new SqlCommand("select roleName from Role",con);
                dr = cmd.ExecuteReader();
                cboRole.Items.Clear();
                while(dr.Read()){
                    cboRole.Items.Add((string)dr["roleName"]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally { con.Close(); }

        }

        private void RegisterEventMove()
        {
            pBanner.MouseDown += pBanner_MouseDown;
            pBanner.MouseUp += pBanner_MouseUp;
            pBanner.MouseMove += pBanner_MouseMove;
        }

        void pBanner_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 20;
                this.SetDesktopLocation(mouseX,mouseY);
            }
        }

        void pBanner_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        void pBanner_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) panelAcount.Enabled = true;            
            else panelAcount.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
