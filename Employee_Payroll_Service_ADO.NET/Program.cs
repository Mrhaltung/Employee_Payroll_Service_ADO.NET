using System;

namespace Employee_Payroll_Service_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Employee Payroll Service ADO.NET \n");
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();

            employee.EmployeeId = 1;
            employee.EmployeeName = "Mr";
            employee.PhoneNumber = 9518528944;
            employee.Address = "Chandrapur";
            employee.Department = "Full Stack";
            employee.Gender = 'M';
            employee.BasicPay = 10000;
            employee.Deductions = 200;
            employee.TaxablePay = 250;
            employee.Tax = 240;
            employee.NetPay = 500000;
            employee.StartDate = DateTime.Now;
            employee.City = "Chandrapur";
            employee.Country = "India";
            employee.JobDescription = "Manager";
            employee.Month = "Sept";
            employee.EmployeeSalary = 40000;
            employee.SalaryId = 2409;

            //repo.AddEmployee(employee);

            Console.WriteLine("\n Data is Stored in DataBase.");

            repo.GetEmployeeDetails();

            Console.WriteLine("Your Data is Executed");
        }
    }
}
