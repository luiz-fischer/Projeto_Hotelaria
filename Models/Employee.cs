using System;
using System.ComponentModel.DataAnnotations;
using Repository;


namespace Model {
    public partial class Employee {
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

    }
}