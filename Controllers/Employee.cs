using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller
{
    public class Employee
    {
        public static void AddEmployee(string employeeName)
        {
            new Model.Employee(employeeName);
        }

        public static List<Model.Employee> GetEmployees()
        {
            return Model.Employee.GetEmployees();
        }

        public static Model.Employee GetEmployee(int employeeId)
        {
            return Model.Employee.GetEmployee(employeeId);
        }
        public static void UpdateEmployee(
           int employeeId,
           string employeeName
       )
        {
            Model.Employee.UpdateEmployee(
                employeeId,
                employeeName
            );
        }

        public static void DeleteEmployee(int employeeId)
        {
            try
            {
                Model.Employee.DeleteEmployee(employeeId);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao deletar!");
            }

        }
    }
}