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

using Mart.UserControls;
using Mart.Intefaces;
using Mart.InstanceClasses;

namespace Mart
{
    public partial class UUser : UserControl,IFunctionModel<Employee>,IMessageType
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private SqlConnection con = Connection.getConnection();
        private List<Employee> empList = new List<Employee>();         

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
                Employee user = new Employee(0, "Thoura", "Lai", "Male", DateTime.Parse("2000/10/10"), "lait", "1234", new Role(1,""), true);
                if (Insert(user))
                {
                    this.MessageSuccess("Inserted successfully", "Insert");
                    LoadData();
                } else this.MessageError("Inserted Unsuccessfully","Insert");                    
                
            }else if(sender == btnUpdate){
                Employee user = new Employee(8, "Bora", "Tey", "Female", DateTime.Parse("2011/11/11"), "teyb", "4321", new Role(2, ""), false);
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
                /* Using Stored Procedure */
                da = new SqlDataAdapter("GetActiveEmployees", con);                
                dt = new DataTable();
                da.Fill(dt);
                dgvUser.DataSource = dt;             

                empList.Clear();
                /* Convert DataTable to ArrayList */
                foreach(DataRow row in dt.Rows){
                    Employee emp = new Employee((int)row["empID"], (string)row["firstName"], (string)row["lastName"], (string)row["gender"], (DateTime)row["birthDate"], (string)row["username"], (string)row["password"], new Role((int)row["roleID"], (string)row["roleName"]), (bool)row["status"]);                    
                    empList.Add(emp);
                }
            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            finally { con.Close(); }
        }
  
        public bool Insert(Employee emp)
        {
            bool success = false;
            try
            {
                con.Open();              
                this.cmd = new SqlCommand("Insert into Employee(lastName,firstName,gender,birthDate,username,password,roleID,status) Values(@ln,@fn,@g,@bd,@un,@pw,@role,@s)",con);
                cmd.Parameters.AddWithValue("@ln", emp.LastName);
                cmd.Parameters.AddWithValue("@fn", emp.FirstName);
                cmd.Parameters.AddWithValue("@g", emp.Gender);
                cmd.Parameters.AddWithValue("@bd", emp.BirthDate);
                cmd.Parameters.AddWithValue("@un", emp.UserName);
                cmd.Parameters.AddWithValue("@pw", emp.Password);
                cmd.Parameters.AddWithValue("@role", emp.Roles.ID);
                cmd.Parameters.AddWithValue("@s", emp.Status);
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

        public bool Update(Employee user)
        {
            bool success = false;
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE Employee SET lastName = @ln, firstName = @fn, gender = @g, birthDate = @bd, username = @un, password = @pw, roleID = @roleID, status = @s WHERE empID = @empID", con);                
                cmd.Parameters.AddWithValue("@ln", user.LastName);
                cmd.Parameters.AddWithValue("@fn", user.FirstName);
                cmd.Parameters.AddWithValue("@g", user.Gender);
                cmd.Parameters.AddWithValue("@bd", user.BirthDate);
                cmd.Parameters.AddWithValue("@un", user.UserName);
                cmd.Parameters.AddWithValue("@pw", user.Password);
                cmd.Parameters.AddWithValue("@roleID", user.Roles.ID);
                cmd.Parameters.AddWithValue("@s", user.Status);
                cmd.Parameters.AddWithValue("@empID",user.ID);
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
                cmd = new SqlCommand("DELETE FROM Employee WHERE empID = @id", con);
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
