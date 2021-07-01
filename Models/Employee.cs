using System;

namespace Model {
    public partial class Employee {
        private int EmployeeId { get; set; }
        private string EmployeeName { get; set; }

        public Employee(
            int employeeId, 
            string employeeName
        )
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }

        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   EmployeeId == employee.EmployeeId &&
                   EmployeeName == employee.EmployeeName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmployeeId, EmployeeName);
        }
    }
}