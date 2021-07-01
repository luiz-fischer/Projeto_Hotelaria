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
    public partial class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("products")] 
        public int ProductId { get; set; }
        public virtual Reservation Reservation { get; set; }
        [ForeignKey("reservations")] 
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public Expense()
        {

        }
        public Expense(
            int productId,
            int reservationId,
            DateTime date,
            double value
        )
        {
            ProductId = productId;
            ReservationId = reservationId;
            Date = date;
            Value = value;

            var db = new Context();
            db.Expenses.Add(this);
            db.SaveChanges();
        }

        public override bool Equals(object obj)
        {
            return obj is Expense expense &&
                   ExpenseId == expense.ExpenseId &&
                   ProductId == expense.ProductId &&
                   ReservationId == expense.ReservationId &&
                   Date == expense.Date &&
                   Value == expense.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ExpenseId, ProductId, ReservationId, Date, Value);
        }
    }
}