using System;

namespace Model
{
    public partial class Expense
    {
        private int ExpenseId { get; set; }
        private int ProductId { get; set; }
        private int ReservationId { get; set; }
        private DateTime Date { get; set; }
        private double Value { get; set; }

        public Expense()
        {

        }
        public Expense(
            int expenseId,
            int productId,
            int reservationId,
            DateTime date,
            double value
        )
        {
            ExpenseId = expenseId;
            ProductId = productId;
            ReservationId = reservationId;
            Date = date;
            Value = value;
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