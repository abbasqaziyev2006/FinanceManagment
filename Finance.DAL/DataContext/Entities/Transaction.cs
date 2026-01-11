namespace Finance.DAL.DataContext.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Category { get; set; } = string.Empty;
    }
    public enum TransactionType
    {
        Income,
        Expense
    }

}


