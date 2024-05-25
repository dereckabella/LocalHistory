using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalHistory.Data;
using LocalHistory.Models;
using LocalHistory.Data;

public class DocumentController : Controller
{
    private readonly ApplicationDbContext _context;

    public DocumentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Documents.ToListAsync());
    }

    // Create, Edit, Delete, Details actions
}