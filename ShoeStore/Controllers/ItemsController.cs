using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Data;
using ShoeStore.ViewModels;

namespace ShoeStore.Controllers;

[Authorize]
public class ItemsController : Controller
{
    private readonly AppDbContext _context;

    public ItemsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Items
    public async Task<IActionResult> Index()
    {
        return View(await _context.Items.ToListAsync());
    }

    // GET: Items/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Items == null)
        {
            return NotFound();
        }

        var item = await _context.Items
            .FirstOrDefaultAsync(m => m.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    // GET: Items/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Items/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ItemsViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        viewModel.Item.ImageFileName = Guid.NewGuid() +
                                             Path.GetExtension(viewModel.File.FileName);
        var savePath = Path.Combine(
            Directory.GetCurrentDirectory(), "wwwroot/img/stuffs",
            viewModel.Item.ImageFileName
        );
        await using var stream = new FileStream(savePath, FileMode.Create);
        await viewModel.File.CopyToAsync(stream);

        _context.Add(viewModel.Item);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Items/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Items == null)
        {
            return NotFound();
        }

        var item = await _context.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        var itemsViewModel = new ItemsViewModel
        {
            Item = item
        };
        return View(itemsViewModel);
    }

    // POST: Items/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ItemsViewModel viewModel)
    {
        if (id != viewModel.Item.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(viewModel);

        try
        {
            if (viewModel.File != null)
            {
                var oldImage = viewModel.Item.ImageFileName;
                var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/img/stuffs/", oldImage);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                viewModel.Item.ImageFileName = Guid.NewGuid() +
                                                               Path.GetExtension(viewModel.File.FileName);
                var savePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/img/stuffs",
                    viewModel.Item.ImageFileName
                );

                await using var stream = new FileStream(savePath, FileMode.Create);
                await viewModel.File.CopyToAsync(stream);
            }

            _context.Update(viewModel.Item);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemExists(viewModel.Item.Id))
            {
                return NotFound();
            }

            throw;
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Items/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Items == null)
        {
            return NotFound();
        }

        var item = await _context.Items
            .FirstOrDefaultAsync(m => m.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    // POST: Items/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Items == null)
        {
            return Problem("Entity set 'AppDbContext.Items'  is null.");
        }
        var item = await _context.Items.FindAsync(id);
        if (item != null)
        {
            var oldImage = item.ImageFileName;
            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/img/stuffs/", oldImage);
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _context.Items.Remove(item);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ItemExists(int id)
    {
        return _context.Items.Any(e => e.Id == id);
    }
}