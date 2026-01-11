using Finance.DAL.DataContext.Entities;

namespace Finance.BLL.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetAllInvoicesAsync();
        Task<Invoice?> GetInvoiceByIdAsync(int id);
        Task CreateInvoiceAsync(Invoice invoice);
        Task UpdateInvoiceAsync(Invoice invoice);
        Task DeleteInvoiceAsync(int id);
    }
}
