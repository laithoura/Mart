using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using Mart.InstanceClass;
using Mart.UserControls;
using Mart.Intefaces;

namespace Mart
{
    public partial class UUser : UserControl,IFunctionModel<User>,IMessageType
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private SqlConnection con = Connection.getConnection();

        private static UUser _instance;
        public static UUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UUser();
                return _instance;
            }
        }
        public UUser()
        {
            InitializeComponent();
            LoadData();
            RegisterEvent();
            List<User> list = new List<User>();            
        }

        private void RegisterEvent()
        {            
            btnAdd.Click += DoClick;           
            btnUpdate.Click += DoClick;
            btnDelete.Click += DoClick;
        }

        private void DoClick(object sender, EventArgs e)
        {
            if(sender == btnAdd){
                User user = new User(0, "Thoura", "Lai", "Male", DateTime.Parse("2000/10/10"), "lait", "1234", 1, true);
                if (Insert(user))
                {
                    this.MessageSuccess("Inserted successfully", "Insert");
                    LoadData();
                } else this.MessageError("Inserted Unsuccessfully","Insert");                    
                
            }else if(sender == btnUpdate){
                User user = new User(8, "Bora", "Tey", "Female", DateTime.Parse("2011/11/11"), "teyb", "4321", 2, false);
                if (Update(user))
                {
                    this.MessageSuccess("Updated successfully", "Update");
                    LoadData();
                } else this.MessageError("Updated Unsuccessfully","Update");                                    

            }else if(sender == btnDelete){
                DialogResult dr = this.MessageVerify("Do you want to delete?","Delete");
                if(dr == DialogResult.Yes){
                    if (Delete(6))
                    {
                        MessageSuccess("Deleted successfully", "Delete");
                        LoadData();
                    }
                    else MessageError("Deleted Unsuccessfully", "Delete");
                    
                }else if(dr == DialogResult.No){
                    // if no 
                }
                else
                {
                    // if cancel
                }               
            }
        }

        public void LoadData()
        {
            try
            {
                con.Open();
                this.da = new SqlDataAdapter("Select * from tbUser",con);
                this.dt = new DataTable();
                da.Fill(dt);
                dgvUser.DataSource = dt;               
            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            finally { con.Close(); }
        }
  
        public bool Insert(User user)
        {
            bool success = false;
            try
            {
                con.Open();              
                this.cmd = new SqlCommand("Insert into tbUser(lastName,firstName,gender,birthDate,username,password,roleID,status) Values(@ln,@fn,@g,@bd,@un,@pw,@role,@s)",con);
                cmd.Parameters.AddWithValue("@ln", user.LastName);
                cmd.Parameters.AddWithValue("@fn", user.FirstName);
                cmd.Parameters.AddWithValue("@g", user.Gender);
                cmd.Parameters.AddWithValue("@bd", user.BirthDate);
                cmd.Parameters.AddWithValue("@un", user.UserName);
                cmd.Parameters.AddWithValue("@pw", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@s", user.Status);
                if (cmd.ExecuteNonQuery() > 0) success = true;
            }
            catch (Exception e)
            {
                success = false;
                MessageBox.Show(e.Message) ;
            }
            finally { con.Close(); }

            return success;
        }

        public bool Update(User user)
        {
            bool success = false;
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE tbUser SET lastName = @ln, firstName = @fn, gender = @g, birthDate = @bd, username = @un, password = @pw, roleID = @roleID, status = @s WHERE userID = @userID",con);                
                cmd.Parameters.AddWithValue("@ln", user.LastName);
                cmd.Parameters.AddWithValue("@fn", user.FirstName);
                cmd.Parameters.AddWithValue("@g", user.Gender);
                cmd.Parameters.AddWithValue("@bd", user.BirthDate);
                cmd.Parameters.AddWithValue("@un", user.UserName);
                cmd.Parameters.AddWithValue("@pw", user.Password);
                cmd.Parameters.AddWithValue("@roleID", user.Role);
                cmd.Parameters.AddWithValue("@s", user.Status);
                cmd.Parameters.AddWithValue("@userID",user.ID);
                if(cmd.ExecuteNonQuery() > 0) success = true;             
            }
            catch (Exception e)
            {
                success = false;
                MessageBox.Show(e.Message);
            }
            finally { con.Close(); }
            return success;
        }

        public bool Delete(int id)
        {
            bool success = false;
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM tbUser WHERE userID = @id",con);
                cmd.Parameters.AddWithValue("@id",id);
                if (cmd.ExecuteNonQuery() > 0) success = true;               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                success = false;                
            }
            finally { con.Close(); }
            return success;
        }

        public void MessageSuccess(string des, string title)
        {
            MessageBox.Show(des,title,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void MessageError(string des, string title)
        {
            MessageBox.Show(des, title, MessageBoxButtons.OK, MessageBoxIcon.Error);       
        }

        public void MessageWarning(string des, string title)
        {
            MessageBox.Show(des,title,MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        public DialogResult MessageVerify(string des, string title)
        {
            return MessageBox.Show(des, title,MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
       
}
