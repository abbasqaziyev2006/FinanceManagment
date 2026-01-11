using Finance.BLL.Services.Contracts;
using Finance.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Finance.BLL.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IFinanceService _financeService;

        public TransactionsController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        public async Task<IActionResult> Index()
        {
            var transactions = await _financeService.GetAllTransactionsAsync();
            return View(transactions);
        }

        public IActionResult Create()
        {
            return View(new Transaction { Date = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                await _financeService.CreateTransactionAsync(transaction);
                TempData["Success"] = "Əməliyyat uğurla əlavə edildi";
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var transaction = await _financeService.GetTransactionByIdAsync(id);
            if (transaction == null) return NotFound();
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                await _financeService.UpdateTransactionAsync(transaction);
                TempData["Success"] = "Əməliyyat uğurla yeniləndi";
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _financeService.DeleteTransactionAsync(id);
            TempData["Success"] = "Əməliyyat silindi";
            return RedirectToAction(nameof(Index));
        }
    }
}