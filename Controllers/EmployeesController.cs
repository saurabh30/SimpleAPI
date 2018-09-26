using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleAPI.Models;

namespace SimpleAPI.Controllers
{
    public class EmployeesController : ApiController
    {


        public Employee GetEmployee(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=DEL1-DHP-40424\\SQLEXPRESS;Initial Catalog=EMPLOYEEDB;Integrated Security=True;";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "Select * from Employee where Id=" + id + "";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                Employee emp = null;
                while (reader.Read())
                {
                    emp = new Employee();
                    emp.Id = Convert.ToInt32(reader.GetValue(0));
                    emp.Name = reader.GetValue(1).ToString();
                    emp.Location = reader.GetValue(2).ToString();
                }
                myConnection.Close();
                return emp;
            }
            catch (Exception ex)
            {

            }
            return null;
            //var employee = db.Employees.Find(id);
            //if (employee == null) return NotFound();
            //return Ok(employee);
        }
    }
}
