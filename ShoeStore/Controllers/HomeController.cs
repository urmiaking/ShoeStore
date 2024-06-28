using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Data;
using ShoeStore.Extensions;
using ShoeStore.Models;
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

    public async Task<IActionResult> AddToCart(int id)
    {
        if (!User.Identity!.IsAuthenticated)
            return RedirectToAction("Login", "Account");

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == User.Identity.Name);

        if (user is null)
            return RedirectToAction("Login", "Account");

        var item = await _context.Items.FindAsync(id);

        if (item is null)
            return NotFound();

        var cart = new Cart
        {
            Item = item,
            User = user
        };

        await _context.Carts.AddAsync(cart);
        await _context.SaveChangesAsync();

        return RedirectToAction("Carts");
    }

    public async Task<IActionResult> Carts()
    {
        if (!User.Identity!.IsAuthenticated)
            return RedirectToAction("Login", "Account");

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == User.Identity.Name);

        var carts = await _context.Carts
            .Include(c => c.Item)
            .Where(c => c.UserId == user.Id).ToListAsync();

        return View(carts);
    }

    public async Task<IActionResult> RemoveFromCart(int id)
    {

        if (!User.Identity!.IsAuthenticated)
            return RedirectToAction("Login", "Account");

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == User.Identity.Name);

        if (user is null)
            return RedirectToAction("Login", "Account");

        var userCart = await _context.Carts.FirstOrDefaultAsync(c => c.User == user && c.ItemId == id);

        _context.Carts.Remove(userCart);
        await _context.SaveChangesAsync();

        return RedirectToAction("Carts");
    }
}