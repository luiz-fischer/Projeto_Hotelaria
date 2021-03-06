using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;
using Repository;

namespace Model
{
    public class Clean 
    {
        [Key]
        public int CleanId { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("employees")]
        public int EmployeeId { get; set; }
        [Required]
        public virtual Room Room { get; set; }
        [ForeignKey("rooms")]
        public int RoomId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        readonly Room room;

        public Clean()
        {
        }

        public Clean(
            Employee employee,
            Room room,
            DateTime date
        )
        {   
            RoomId = room.IdRoom;
            EmployeeId = employee.EmployeeId;
            Date = date;
            employee.AddClean(this);
            room.AddClean(this);

            var db = new Context();
            db.Cleans.Add(this);
            db.SaveChanges();

        }

        public Clean(int roomId)
        {
            room.IdRoom = roomId;
            var db = new Context();
            try
            {
                db.Cleans.Add(this);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro!");
            }
        }

        public void AddRoom(Room room)
        {
            var db = new Context();
            CleanRoom cleanRooms = new CleanRoom()
            {
                IdRoom = room.IdRoom,
                IdClean = CleanId
            };  

            db.CleanRooms.Add(cleanRooms);
            db.SaveChanges();
        }

        public override bool Equals(object obj)
        {
            return obj is Clean clean &&
                   CleanId == clean.CleanId &&
                   EmployeeId == clean.EmployeeId &&
                   Date == clean.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CleanId, EmployeeId, Date);
        }

        public static Clean GetClean(int cleanId)
        {
            var db = new Context();
            return (from clean in db.Cleans
                    where clean.CleanId == cleanId
                    select clean).First();
        }
        public static List<Clean> GetCleans()
        {
            var db = new Context();
            return db.Cleans.ToList();
        }
        

        public int GetRoomsByEmployee()
        {
            Context db = new Context();
            IEnumerable<int> rooms =
            from room in db.CleanRooms
            where room.IdClean == CleanId
            select room.IdRoom;

            Employee employee = Employee.GetEmployee(EmployeeId);

            return rooms.Count();
        }

        public static void UpdateClean(
            int cleanId,
            int employeeId,
            DateTime date
        )
        {
            var db = new Context();
            try
            {
                Clean clean = db.Cleans.First(clean => clean.CleanId == cleanId);
                clean.EmployeeId = employeeId;
                clean.Date = date;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Atualizar!");
            }
        }

        public static void DeleteClean(int cleanId)
        {
            var db = new Context();
            try
            {
                Clean clean = db.Cleans.First(clean => clean.CleanId == cleanId);
                db.Remove(clean);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao deletar!");
            }
        }
        public static void SetCleanDone(int cleanId, int employeeId)
        {
            var db = new Context();

            Clean clean = GetClean(cleanId);
            clean.EmployeeId = employeeId;
            clean.Date = DateTime.Now;
            db.SaveChanges();
        }
    }
}
