using Finance.BLL.Services.Contracts;
using Finance.DAL.DataContext;
using Finance.DAL.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finance.BLL.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly AppDbContext _context;

        public FinanceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.OrderByDescending(t => t.Date).ToListAsync();
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<decimal> GetTotalIncomeAsync()
        {
            return await _context.Transactions
                .Where(t => t.Type == TransactionType.Income)
                .SumAsync(t => (decimal?)t.Amount) ?? 0;
        }

        public async Task<decimal> GetTotalExpensesAsync()
        {
            return await _context.Transactions
                .Where(t => t.Type == TransactionType.Expense)
                .SumAsync(t => (decimal?)t.Amount) ?? 0;
        }

        public async Task<decimal> GetBalanceAsync()
        {
            var income = await GetTotalIncomeAsync();
            var expenses = await GetTotalExpensesAsync();
            return income - expenses;
        }
    }
}