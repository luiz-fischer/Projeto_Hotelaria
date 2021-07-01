using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Repository;

namespace Model {
    public partial class Clean {
        [Key]
        public int CleanId { get; set; }
        [ForeignKey("guests")] 
        public int RoomId { get; set; }

        [ForeignKey("employees")] 
        public int EmployeeId { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public Clean() {

        }
        public Clean(
            int roomId,
            int employeeId,
            DateTime date
        )
        {
            RoomId = roomId;
            EmployeeId = employeeId;
            Date = date;

            var db = new Context();
            db.Cleans.Add(this);
            db.SaveChanges();
            
            
        }

        public override bool Equals(object obj)
        {
            return obj is Clean clean &&
                   CleanId == clean.CleanId &&
                   RoomId == clean.RoomId &&
                   EmployeeId == clean.EmployeeId &&
                   Date == clean.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CleanId, RoomId, EmployeeId, Date);
        }
    }
}