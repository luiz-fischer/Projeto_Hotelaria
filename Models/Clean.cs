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
    public class Clean
    {
        [Key]
        public int CleanId { get; set; }
        public virtual Room Room { get; set; }
        [ForeignKey("rooms")]
        public int RoomId { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("employees")]

        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }

        public Clean()
        {

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

        public Clean(int roomId)
        {
            RoomId = roomId;
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

        public static Clean GetClean(int cleanId)
        {
            var db = new Context();
            return db.Cleans.Find(cleanId);
        }
        public static List<Clean> GetCleans()
        {
            var db = new Context();
            return db.Cleans.ToList();
        }
        public static Clean GetCleanByRoom(int roomId)
        {
            var db = new Context();
            IEnumerable<Clean> query =
                        from clean in db.Cleans
                        where clean.RoomId == roomId
                        select clean;
            return query.Last();
        }

        public static Clean VerifyClean(int reservationId)
        {
            Reservation reservation = Reservation.GetReservation(reservationId);
            Clean clean = GetCleanByRoom(reservation.RoomId);
            return clean;
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
            int roomId,
            int employeeId,
            DateTime date
        )
        {
            var db = new Context();
            try
            {
                Clean clean = db.Cleans.First(clean => clean.CleanId == cleanId);
                clean.RoomId = roomId;
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