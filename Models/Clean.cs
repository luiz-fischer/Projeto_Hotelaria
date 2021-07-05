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
        public DateTime Date { get; set; }
        public List<Model.Room> rooms = new();
        Model.Room room;

        public Clean()
        {
        }

        public Clean(
            // int roomId,
            Model.Employee employee,
            DateTime date
        )
        {
            // IdRoom = roomId;
            EmployeeId = employee.EmployeeId;
            Date = date;
            rooms = new List<Model.Room>();
            employee.AddClean(this);

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

        public void AddRoom(Model.Room room)
        {
            var db = new Context();
            Model.CleanRoom cleanRooms = new()
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

        public static Model.Clean GetClean(int cleanId)
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
        

        public static void SetCleanDone(int cleanId, int employeeId)
        {
            var db = new Context();

            Clean clean = GetClean(cleanId);
            clean.EmployeeId = employeeId;
            clean.Date = DateTime.Now;
            db.SaveChanges();
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
    }
}