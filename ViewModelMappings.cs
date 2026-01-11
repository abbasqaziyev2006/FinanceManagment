
using System.Linq;
using Finance.DAL.DataContext.Entities;

namespace Finance.BLL.ViewModels
{
    public static class ViewModelMappings
    {
        // Client
        public static ClientViewModel ToViewModel(this Client c) => new()
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Phone = c.Phone,
            Company = c.Company,
            CreatedDate = c.CreatedDate
        };

        public static Client ToEntity(this ClientViewModel vm) => new()
        {
            Id = vm.Id,
            Name = vm.Name,
            Email = vm.Email,
            Phone = vm.Phone,
            Company = vm.Company,
            CreatedDate = vm.CreatedDate
        };

        // Transaction
        public static TransactionViewModel ToViewModel(this Transaction t) => new()
        {
            Id = t.Id,
            Description = t.Description,
            Amount = t.Amount,
            Type = t.Type,
            Date = t.Date,
            Category = t.Category
        };

        public static Transaction ToEntity(this TransactionViewModel vm) => new()
        {
            Id = vm.Id,
            Description = vm.Description,
            Amount = vm.Amount,
            Type = vm.Type,
            Date = vm.Date,
            Category = vm.Category
        };

        // Invoice item
        public static InvoiceItemViewModel ToViewModel(this InvoiceItem i) => new()
        {
            Id = i.Id,
            InvoiceId = i.InvoiceId,
            Description = i.Description,
            Quantity = i.Quantity,
            UnitPrice = i.UnitPrice
        };

        public static InvoiceItem ToEntity(this InvoiceItemViewModel vm) => new()
        {
            Id = vm.Id,
            InvoiceId = vm.InvoiceId,
            Description = vm.Description,
            Quantity = vm.Quantity,
            UnitPrice = vm.UnitPrice
        };

        // Invoice
        public static InvoiceViewModel ToViewModel(this Invoice inv) => new()
        {
            Id = inv.Id,
            ClientId = inv.ClientId,
            ClientName = inv.Client?.Name ?? string.Empty,
            InvoiceNumber = inv.InvoiceNumber,
            Amount = inv.Amount,
            IssueDate = inv.IssueDate,
            DueDate = inv.DueDate,
            Status = inv.Status,
            Items = inv.Items?.Select(i => i.ToViewModel()).ToList() ?? new()
        };

        public static Invoice ToEntity(this InvoiceViewModel vm) => new()
        {
            Id = vm.Id,
            ClientId = vm.ClientId,
            InvoiceNumber = vm.InvoiceNumber,
            Amount = vm.Amount,
            IssueDate = vm.IssueDate,
            DueDate = vm.DueDate,
            Status = vm.Status,
            Items = vm.Items?.Select(i => i.ToEntity()).ToList() ?? new()
        };
    }
}