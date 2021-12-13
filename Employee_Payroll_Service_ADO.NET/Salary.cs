using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Employee_Payroll_Service_ADO.NET
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Service_ADO_NET;Integrated Security=True");
        }

        public int UpdateEmployeeSalary(EmployeeModel model)
        {
            SqlConnection salaryconnection = ConnectionSetup();

            int Salary = 0;
            try
            {
                using (salaryconnection)
                {
                    salaryconnection.Open();
                    string query = @"update Employee set EmployeeSalary=@salary where SalaryId=@Id and Month=@month and EmployeeId=@Empid";
        
                    EmployeeModel employeemodel = new EmployeeModel();
                    SqlCommand command = new SqlCommand(query /*"SpAddEmployees"*/, salaryconnection);
                    //command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", model.SalaryId);
                    command.Parameters.AddWithValue("@Empid", model.EmployeeId);
                    command.Parameters.AddWithValue("@month", model.Month);
                    command.Parameters.AddWithValue("@salary", model.EmployeeSalary);
                    //command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);

                    //salaryconnection.Open();
                    //SqlDataReader dr = command.ExecuteReader();
                    var result = command.ExecuteNonQuery();
                    salaryconnection.Close();

                    if (result != 0)
                    {
                        salaryconnection.Open();
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                employeemodel.EmployeeId = (int)dr["EmployeeId"];
                                // employeemodel.EmployeeName = dr["EmployeeName"].ToString();
                                employeemodel.EmployeeSalary = (int)dr["EmployeeSalary"];
                                employeemodel.Month = dr["Month"].ToString();
                                employeemodel.SalaryId = (int)dr["SalaryId"];

                                Console.WriteLine("{0},{1},{2},{3}", employeemodel.EmployeeId /*employeemodel.EmployeeName*/, employeemodel.EmployeeSalary, employeemodel.Month, employeemodel.SalaryId);

                                Salary = employeemodel.EmployeeSalary;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                salaryconnection.Close();
            }
            return Salary;
        }

        public void GetEmployeeDetails()
        {
            SqlConnection salaryconnection = ConnectionSetup();

            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (salaryconnection)
                {
                    string query = @"Select EmployeeId,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deductions,TaxablePay,Tax,NetPay,StartDate,City,Country,JobDescription,Month,EmployeeSalary,SalaryId from Employee";

                    SqlCommand cmd = new SqlCommand(query, salaryconnection);

                    salaryconnection.Open();
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
                                , employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Department,
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
                    salaryconnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                salaryconnection.Close();
            }
        }
    }
}
