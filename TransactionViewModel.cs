Finance.BLL\ViewModels/TransactionViewModel.cs
using System;
using Finance.DAL.DataContext.Entities;

namespace Finance.BLL.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; } = string.Empty;

        public string TypeDisplay => Type.ToString();
    }
}