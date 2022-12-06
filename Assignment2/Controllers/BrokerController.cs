using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2.Data;
using Assignment2.Models;
using Assignment2.Models.ViewModels;

namespace Assignment2.Controllers
{
    public class BrokerController : Controller
    {
        private readonly MarketDbContext _context;

        public BrokerController(MarketDbContext context)
        {
            _context = context;
        }

        // GET: Broker
        public async Task<IActionResult> Index(string? id)
        {
            var viewModel = new BrokeragesViewModel {
                Brokers = await _context.Brokers
                  .Include(i => i.Subscriptions)
                  .ThenInclude(i => i.Client)
                  .AsNoTracking()
                  .OrderBy(i => i.Title)
                  .ToListAsync()
            };

            if (id != null) {
                ViewData["BrokerId"] = id;
                viewModel.Subscriptions = viewModel.Brokers.Where(
                    x => x.Id == id).Single().Subscriptions;
            }

            return View(viewModel);

            
        }

        // GET: Broker/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Brokers == null)
            {
                return NotFound();
            }

            var broker = await _context.Brokers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (broker == null)
            {
                return NotFound();
            }

            return View(broker);
        }

        // GET: Broker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Broker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Fee")] Broker broker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(broker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(broker);
        }

        // GET: Broker/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Brokers == null)
            {
                return NotFound();
            }

            var broker = await _context.Brokers.FindAsync(id);
            if (broker == null)
            {
                return NotFound();
            }
            return View(broker);
        }

        // POST: Broker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Fee")] Broker broker)
        {
            if (id != broker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(broker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrokerExists(broker.Id))
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
            return View(broker);
        }

        // GET: Broker/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Brokers == null)
            {
                return NotFound();
            }

            var broker = await _context.Brokers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (broker == null)
            {
                return NotFound();
            }

            return View(broker);
        }

        // POST: Broker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Brokers == null)
            {
                return Problem("Entity set 'MarketDbContext.Brokers'  is null.");
            }
            var broker = await _context.Brokers.FindAsync(id);
            if (broker != null)
            {
                _context.Brokers.Remove(broker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrokerExists(string id)
        {
          return _context.Brokers.Any(e => e.Id == id);
        }
    }
}
