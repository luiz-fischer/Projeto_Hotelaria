using System;

namespace Model {
    public partial class Clean {
        private int CleanId { get; set; }
        private int RoomId { get; set; }
        private int EmployeeId { get; set; }
        private DateTime Date { get; set; }

        public Clean(
            int cleanId,
            int roomId,
            int employeeId,
            DateTime date
        )
        {
            CleanId = cleanId;
            RoomId = roomId;
            EmployeeId = employeeId;
            Date = date;
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