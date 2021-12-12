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

        public void GetEmployeeDetails()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.con)
                {
                    string query = @"Select EmployeeId,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deductions,TaxablePay,Tax,NetPay,StartDate,City,Country,JobDescription,Month,EmployeeSalary,SalaryId from Employee";

                    SqlCommand cmd = new SqlCommand(query, this.con);

                    this.con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeId = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.PhoneNumber = Convert.ToInt64(dr.GetString(2));
                            employeeModel.Address = dr.GetString(3);
                            employeeModel.Department = dr.GetString(4);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(5));
                            employeeModel.BasicPay = dr.GetDouble(6);
                            employeeModel.Deductions = dr.GetDouble(7);
                            employeeModel.TaxablePay = dr.GetDouble(8);
                            employeeModel.Tax = dr.GetDouble(9);
                            employeeModel.NetPay = dr.GetDouble(10);
                            employeeModel.StartDate = Convert.ToDateTime(dr.GetDateTime(11));
                            employeeModel.City = dr.GetString(12);
                            employeeModel.Country = dr.GetString(13);
                            employeeModel.JobDescription = dr.GetString(14);
                            employeeModel.Month = dr.GetString(15);
                            employeeModel.EmployeeSalary = dr.GetInt32(16);
                            employeeModel.SalaryId = dr.GetInt32(17);

                            Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11} | {12} | {13} | {14} | {15} | {16} | {17} "
                                ,employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Department,
                                employeeModel.Gender, employeeModel.BasicPay, employeeModel.Deductions, employeeModel.TaxablePay, employeeModel.Tax, employeeModel.NetPay,
                                employeeModel.StartDate, employeeModel.City, employeeModel.Country, employeeModel.JobDescription, employeeModel.Month, employeeModel.EmployeeSalary,
                                employeeModel.SalaryId);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();
                    this.con.Close();
                }
            }
            catch (Exception e)
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
