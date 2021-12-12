using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Employee_Payroll_Service_ADO.NET
{
    public class EmployeeRepo
    {
        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Service_ADO_NET;Integrated Security=True";

        SqlConnection con = new SqlConnection(ConnectionString);

        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.con)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployees", this.con);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    command.Parameters.AddWithValue("@JobDescription", model.JobDescription);
                    command.Parameters.AddWithValue("@Month", model.Month);
                    command.Parameters.AddWithValue("@EmployeeSalary", model.EmployeeSalary);
                    command.Parameters.AddWithValue("@SalaryId", model.SalaryId);

                    this.con.Open();
                    var result = command.ExecuteNonQuery();
                    this.con.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.con.Close();
            }
        }
    }
}
