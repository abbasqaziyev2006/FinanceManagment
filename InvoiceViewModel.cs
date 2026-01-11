using System;
using System.Collections.Generic;
using Finance.DAL.DataContext.Entities;

namespace Finance.BLL.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public InvoiceStatus Status { get; set; }
        public List<InvoiceItemViewModel> Items { get; set; } = new();
    }
}