using Finance.DAL.DataContext.Entities;

namespace Finance.BLL.Services.Contracts
{
    public interface IFinanceService
    {
        Task<List<Transaction>> GetAllTransactionsAsync();
        Task<Transaction?> GetTransactionByIdAsync(int id);
        Task CreateTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(int id);
        Task<decimal> GetTotalIncomeAsync();
        Task<decimal> GetTotalExpensesAsync();
        Task<decimal> GetBalanceAsync();
    }
}