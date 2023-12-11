using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using footballplayers.Data;  // Импорт пространства имен для ApplicationDbContext
using footballplayers.Models;  // Импорт пространства имен для моделей
using System;

public class PlayersController : Controller
{
    private readonly ApplicationDbContext _context;

    public PlayersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Players
    public IActionResult Index()
    {
        var players = _context.Players.Include(p => p.Team).ToList();
        return View(players);
    }

    // GET: Players/Add
    public IActionResult Add()
    {
        var teams = _context.Teams.ToList();
        ViewBag.Teams = teams;
        return View();
    }

    // POST: Players/Add
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Player player)
    {
        if (ModelState.IsValid)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        var teams = _context.Teams.ToList();
        ViewBag.Teams = teams;
        return View(player);
    }

    // GET: Players/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var player = _context.Players.Find(id);

        if (player == null)
        {
            return NotFound();
        }

        var teams = _context.Teams.ToList();
        ViewBag.Teams = teams;
        return View(player);
    }

    // POST: Players/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int? id, Player player)
    {
        if (id == null || id != player.PlayerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(player);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(player.PlayerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        var teams = _context.Teams.ToList();
        ViewBag.Teams = teams;
        return View(player);
    }

    private bool PlayerExists(int id)
    {
        return _context.Players.Any(p => p.PlayerId == id);
    }
}
