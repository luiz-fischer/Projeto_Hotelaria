using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Repository;


namespace Model
{
    public partial class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public Employee(
            string employeeName
        )
        {
            EmployeeName = employeeName;

            var db = new Context();
            db.Employees.Add(this);
            db.SaveChanges();
        }

        public static Employee GetEmployee(int employeeId)
        {
            var db = new Context();
            return (from employee in db.Employees
                    where employee.EmployeeId == employeeId
                    select employee).First();
        }

        public static List<Employee> GetEmployees()
        {
            var db = new Context();
            return db.Employees.ToList();
        }

        public static void UpdateEmployee(int employeeId, string employeeName)
        {
            var db = new Context();
            try
            {
                Employee employee = db.Employees.First(employee => employee.EmployeeId == employeeId);
                employee.EmployeeId = employeeId;
                employee.EmployeeName = employeeName;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Atualizar!");
            }
        }
        public static void DeleteEmployee(int employeeId)
        {
            var db = new Context();
            try
            {
                Employee employee = db.Employees.First(employee => employee.EmployeeId == employeeId);
                db.Remove(employee);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao deletar!");
            }
        }
    }
}