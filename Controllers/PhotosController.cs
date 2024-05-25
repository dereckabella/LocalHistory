using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalHistory.Data;
using LocalHistory.Models;
using LocalHistory.Data;
using Microsoft.AspNetCore.Http; // Add this namespace for IFormFile

public class PhotosController : Controller
{
    private readonly ApplicationDbContext _context;

    public PhotosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Photos/Create
    public IActionResult Create()
    {
        return View();
    }



    public IActionResult Index()
    {
        var photos = _context.Photos.ToList(); // Assuming _context is your ApplicationDbContext
        return View(photos);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Photo photo, IFormFile imageData)
    {
        if (ModelState.IsValid)
        {
            if (imageData != null && imageData.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await imageData.CopyToAsync(stream);
                    photo.ImageData = stream.ToArray();
                }
            }

            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(photo);
    }

    // Other action methods like Index, Edit, Delete, etc.
}
