using Finance.BLL.Services;
using Finance.BLL.Services.Contracts;
using Finance.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IClientService _clientService;

        public InvoicesController(IInvoiceService invoiceService, IClientService clientService)
        {
            _invoiceService = invoiceService;
            _clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return View(invoices);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clients = await _clientService.GetAllClientsAsync();
            return View(new Invoice { IssueDate = DateTime.Now, DueDate = DateTime.Now.AddDays(30) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoice.InvoiceNumber = $"INV-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
                await _invoiceService.CreateInvoiceAsync(invoice);
                TempData["Success"] = "Faktura yaradıldı";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clients = await _clientService.GetAllClientsAsync();
            return View(invoice);
        }

        // GET: /Invoices/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null) return NotFound();

            ViewBag.Clients = await _clientService.GetAllClientsAsync();
            return View(invoice);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                await _invoiceService.UpdateInvoiceAsync(invoice);
                TempData["Success"] = "Faktura yeniləndi";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clients = await _clientService.GetAllClientsAsync();
            return View(invoice);
        }

    
        public async Task<IActionResult> Details(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null) return NotFound();
            return View(invoice);
        }
    }
}