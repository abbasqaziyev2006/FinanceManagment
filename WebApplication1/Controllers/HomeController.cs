using System.Diagnostics;
using Finance.BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IFinanceService _financeService;

        public HomeController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalIncome = await _financeService.GetTotalIncomeAsync();
            ViewBag.TotalExpenses = await _financeService.GetTotalExpensesAsync();
            ViewBag.Balance = await _financeService.GetBalanceAsync();

            var transactions = await _financeService.GetAllTransactionsAsync();
            return View(transactions.Take(5));
        }
    }
}

