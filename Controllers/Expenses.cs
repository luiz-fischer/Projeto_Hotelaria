using System;
using System.Collections.Generic;
namespace Controller {
    public class Expenses {
        public static Model.Expense AddExpense(
            int productId,
            int reservationId,
            DateTime date,
            int value
        )
        {
            return new Model.Expense(
                productId,
                reservationId,
                date,
                value
            );
        }

        public static List<Model.Expense> GetExpenses()
        {
            return Model.Expense.GetExpenses();
        }

        public static Model.Expense GetExpense(int expenseId)
        {
            return Model.Expense.GetExpense(expenseId);
        }

        public static void DeleteExpense(int expenseId)
        {
            Model.Expense.DeleteExpense(expenseId);
        }
    }
}