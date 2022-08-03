using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Data;
using ShoeStore.Extensions;
using ShoeStore.ViewModels;

namespace ShoeStore.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index() => View(await _context.Items.ToListAsync());

    public async Task<IActionResult> Details(int id)
    {
        var items = await _context.Items.FindAsync(id);

        if (items is null)
            return NotFound();

        return View(items);
    }

    public async Task<IActionResult> Search(string query)
    {
        var viewModel = new SearchViewModel
        {
            Items = await _context.Items.Where(a => a.Name.Contains(query)).ToListAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Search(SearchViewModel viewModel)
    {
        var items = (await _context.Items.ToListAsync()).Where(a =>
            a.Price.IsBetween(viewModel.FromPrice, viewModel.ToPrice)).ToList();

        viewModel.Items = items;

        return View(viewModel);
    }
}