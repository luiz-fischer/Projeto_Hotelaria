using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;
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

        public static Expense GetExpense(int expenseId)
        {
            var db = new Context();
            return (from expense in db.Expenses
                    where expense.ExpenseId == expenseId
                    select expense).First();
        }

        public static List<Expense> GetExpenses()
        {
            var db = new Context();
            return db.Expenses.ToList();
        }

         public static List<Expense> GetExpenseByReservation(int reservationId)
        {
            var db = new Context();
            IEnumerable<Expense> Expense = 
                from expense in db.Expenses 
                where expense.ReservationId == reservationId 
                select expense;
            return Expense.ToList();
        }

        public static void UpdateExpense(
            int expenseId,
            int productId,
            int reservationId,
            DateTime date,
            double value
        )
        {
            var db = new Context();
            try
            {
                Expense expense = db.Expenses.First(expense => expense.ExpenseId == expenseId);
                expense.ExpenseId = expenseId;
                expense.ProductId = productId;
                expense.ReservationId = reservationId;
                expense.Date = date;
                expense.Value = value;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Atualizar!");
            }
        }
        public static void DeleteExpense(int expenseId)
        {
            var db = new Context();
            try
            {
                Expense expense = db.Expenses.First(expense => expense.ExpenseId == expenseId);
                db.Remove(expense);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao deletar!");
            }
        }
    }
}
