using Microsoft.AspNetCore.Mvc;
using LocalHistory.Models;
using System.Linq;
using LocalHistory.Data;
using Microsoft.EntityFrameworkCore.Migrations;

public class StoriesController : Controller
{
    private readonly ApplicationDbContext _context;

    public StoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Stories/Create
    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Story story)
    {
        if (ModelState.IsValid)
        {
            _context.Stories.Add(story);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(story);
    }


    public IActionResult Index()
    {
        // Retrieve all stories from the database
        var stories = _context.Stories.ToList(); // Adjust this based on your data retrieval logic
        return View(stories); // Pass the list of stories to the view
    }

    public IActionResult Create()
    {
        return View();
    }
}
