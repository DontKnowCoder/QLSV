using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLSV.Data;
using QLSV.Models;

namespace QLSV.Controllers
{
    public class SVsController : Controller
    {
        private readonly QLSVContext _context;

        public SVsController(QLSVContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Trang chủ";
            var students = _context.SV.ToList();
            return View(students);
        }



        // GET: SVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sV = await _context.SV
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sV == null)
            {
                return NotFound();
            }

            return View(sV);
        }

        // GET: SVs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Dob,Class")] SV sV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sV);
                var log = new Log
                {
                    Timestamp = DateTime.Now,
                    Name = sV.Name,
                    Dob = sV.Dob,
                    Class = sV.Class,
                    Action = "Thêm",
                    StudentID = sV.ID
                };

                _context.Logs.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sV);
        }

        // GET: SVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sV = await _context.SV.FindAsync(id);
            if (sV == null)
            {
                return NotFound();
            }
            return View(sV);
        }

        // POST: SVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Dob,Class")] SV sV)
        {
            if (id != sV.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sV);
                    var log = new Log
                    {
                        Timestamp = DateTime.Now,
                        Name = sV.Name,
                        Dob = sV.Dob,
                        Class = sV.Class,
                        Action = "Sửa",
                        StudentID = sV.ID
                    };

                    _context.Logs.Add(log);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SVExists(sV.ID))
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
            return View(sV);
        }

        // GET: SVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sV = await _context.SV
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sV == null)
            {
                return NotFound();
            }

            return View(sV);
        }

        // POST: SVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sV = await _context.SV.FindAsync(id);
            if (sV != null)
            {
                _context.SV.Remove(sV);
                var log = new Log
                {
                    Timestamp = DateTime.Now,
                    Name = sV.Name,
                    Dob = sV.Dob,
                    Class = sV.Class,
                    Action = "Xóa",
                    StudentID = sV.ID
                };

                _context.Logs.Add(log);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SVExists(int id)
        {
            return _context.SV.Any(e => e.ID == id);
        }
        public async Task<IActionResult> Logs()
        {
            var logs = await _context.Logs.ToListAsync(); 
            return View(logs);
        }
    }
}
