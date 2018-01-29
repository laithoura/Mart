using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mart.InstanceClasses;

namespace Mart.InstanceClasses
{
    public class Employee
    {
        private Role role;
        public Role Roles
        { 
            get{
                if (role != null) return role;
                else return new Role(0,"");
            }
            set{
                if (value != null) role = value;
            }
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public bool Status { get; set; }
        public Employee() { }
        public Employee(int id,string firstName,string lastName,string gender, DateTime birthDate, string userName, string password,Role role,bool status){
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.UserName = userName;
            this.Password = password;
            this.Roles = role;
            this.Status = status;
        }
    }
}
