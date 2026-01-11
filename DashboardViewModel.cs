using System.Collections.Generic;

namespace Finance.BLL.ViewModels
{
    public class DashboardViewModel
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionViewModel> RecentTransactions { get; set; } = new();
    }
}