using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Expense, int, Expense> ExpenseData()
        {
            return new ExpenseRepo(); 
        }
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }

    }
}
