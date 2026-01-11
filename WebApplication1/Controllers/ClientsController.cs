using Finance.BLL.Services.Contracts;
using Finance.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Finance.BLL.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientService.CreateClientAsync(client);
                TempData["Success"] = "Müştəri uğurla əlavə edildi";
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null) return NotFound();
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientService.UpdateClientAsync(client);
                TempData["Success"] = "Müştəri məlumatları yeniləndi";
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientService.DeleteClientAsync(id);
            TempData["Success"] = "Müştəri silindi";
            return RedirectToAction(nameof(Index));
        }
    }
}