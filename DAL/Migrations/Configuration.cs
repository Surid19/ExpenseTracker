namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.ExpenseContext> 
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.ExpenseContext context)
        {
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                context.Users.AddOrUpdate(u => u.Uname, 
                    new Models.User
                    {
                        Name = Guid.NewGuid().ToString().Substring(0, 15),
                        Uname = "User-" + i,
                        Password = Guid.NewGuid().ToString().Substring(0, 10), 
                        Type = "General"
                    });
            }

            for (int i = 0; i < 20; i++)
            {
                context.Expenses.AddOrUpdate(e => e.Id, 
                    new Models.Expense
                    {
                        Id = i, 
                        Amount = random.Next(10, 1000), 
                        Category = "Category-" + random.Next(1, 5), 
                        Date = DateTime.Now.AddDays(-random.Next(0, 30)), 
                        Description = Guid.NewGuid().ToString().Substring(0, 20),
                        IsRecurring = random.Next(0, 2) == 1 
                    });
            }


            for (int i = 0; i < 5; i++)
            {
                var totalBudget = random.Next(1000, 5000); 
                var spentAmount = random.Next(0, (int)totalBudget); 

                context.Budgets.AddOrUpdate(b => b.Id, 
                    new Models.Budget
                    {
                        Id = i, 
                        TotalBudget = totalBudget,
                        SpentAmount = spentAmount
                    });
            }



            context.SaveChanges(); 
        }
    }
}
