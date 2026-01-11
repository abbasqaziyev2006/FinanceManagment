using Finance.DAL.DataContext.Entities;

namespace Finance.BLL.Services.Contracts
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int id);
        Task CreateClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int id);
    }
}
