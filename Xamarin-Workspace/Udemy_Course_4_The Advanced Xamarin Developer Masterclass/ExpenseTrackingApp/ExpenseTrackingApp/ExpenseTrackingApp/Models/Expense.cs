using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace ExpenseTrackingApp.Models
{
   public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public float Amount { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }

        public Expense()
        {

        }

        public static async Task<int> InsertExpense(Expense expense)
        {
              return await App.connect.InsertAsync(expense);
        }

        public async static Task<List<Expense>> GetExpenses()
        {
            List<Expense> list = null;
           // await App.connect.CreateTableAsync<Expense>();
            list = await App.connect.Table<Expense>().ToListAsync();

            if (list != null)
            {
                return list;
            }
            else
                return null;

           
        }

        public async static Task<List<Expense>> GetExpensesPerCategory(string category)
        {
            List<Expense> list = null;
          //  await App.connect.CreateTableAsync<Expense>();
            list = await App.connect.Table<Expense>().Where(e => e.Category == category).ToListAsync();

            if (list != null)
            {
                return list;
            }
            else
                return null;

        }

        public async static Task<float> TotalExpensesAmount()
        {
            List<Expense> list = null;
            //  await App.connect.CreateTableAsync<Expense>();
            list = await App.connect.Table<Expense>().ToListAsync();

            return list.Sum(e => e.Amount);
        }


    }
}
