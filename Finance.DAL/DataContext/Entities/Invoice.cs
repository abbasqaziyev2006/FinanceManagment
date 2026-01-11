namespace Finance.DAL.DataContext.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public InvoiceStatus Status { get; set; }
        public List<InvoiceItem> Items { get; set; } = new();

    }
    public enum InvoiceStatus
    {
        Draft,
        Sent,
        Paid,
        Overdue,
        Cancelled
    }
}


