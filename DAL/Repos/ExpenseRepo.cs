using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ExpenseRepo : Repo, IRepo<Expense, int, Expense>
    {
        public ExpenseContext expenseContext;

        public ExpenseRepo(ExpenseContext postContext)
        {
            this.expenseContext = expenseContext;
        }

        public ExpenseRepo()
        {
        }

        public Expense Create(Expense obj)
        {
            db.Expenses.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var expense = Read(id);
            if (expense != null)
            {
                db.Expenses.Remove(expense);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Expense> Read()
        {
            return db.Expenses.ToList();
        }

        public Expense Read(int id)
        {
            return db.Expenses.Find(id);
        }

        public Expense Update(Expense obj)
        {
            var existingExpense = Read(obj.Id);
            if (existingExpense != null)
            {
                db.Entry(existingExpense).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public List<Expense> ReadByCategory(string category)
        {
            return db.Expenses.Where(e => e.Category == category).ToList();
        }

        public List<Expense> ReadByDate(DateTime date)
        {
            return db.Expenses.Where(e => e.Date.Date == date.Date).ToList();
        }

        public List<Expense> ReadRecurring()
        {
            return db.Expenses.Where(e => e.IsRecurring).ToList();
        }
    }
}
