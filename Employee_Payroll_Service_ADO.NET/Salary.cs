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
                    EmployeeModel employeemodel = new EmployeeModel();
                    SqlCommand command = new SqlCommand("SpUpdateEmpsSalary", salaryconnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@salaryId", model.SalaryId);
                    command.Parameters.AddWithValue("@id", model.EmployeeId);
                    command.Parameters.AddWithValue("@month", model.Month);
                    command.Parameters.AddWithValue("@salary", model.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);

                    salaryconnection.Open();

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeemodel.EmployeeId = (int)dr["EmployeeId"];
                            employeemodel.EmployeeName = dr["EmployeeName"].ToString();
                            employeemodel.EmployeeSalary = (int)dr["EmployeeSalary"];
                            employeemodel.Month = dr["Month"].ToString();
                            employeemodel.SalaryId = (int)dr["SalaryId"];

                            Console.WriteLine("{0},{1},{2},{3},{4}", employeemodel.EmployeeId, employeemodel.EmployeeName, employeemodel.EmployeeSalary, employeemodel.Month, employeemodel.SalaryId);

                            Salary = employeemodel.EmployeeSalary;
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
    }
}
