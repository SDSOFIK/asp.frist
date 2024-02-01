using fristclass.webapp.databesContex;
using fristclass.webapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fristclass.webapp.Controllers
{
    public class studentController : Controller
        
    {
        private readonly applicationDBContax _context;
        public studentController(applicationDBContax context)
        {
            _context = context;
           
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var data = await _context.Set< student >().AsNoTracking().ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult>CreateOrEidt(int id)
        {
            if (id == 0)
            {
                return View(new student());
            }
            else
            {
                var data = await _context.Set<student>().FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEidt(int id , student Student)
        {
            if (id == 0)
            {
                if (ModelState.IsValid)
                {
                    await _context.Set<student>().AddAsync(Student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                _context.Set<student>().Update(Student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Student);
        }
        public async Task<IActionResult> delete(int id)
        {
            if (id != 0)
            {
                var data = await _context.Set<student>().FindAsync(id);
                if (data is not null)
                {
                    _context.Set<student>().Remove(data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");



                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Detiles( int id)
        {
            var data = await _context.Set<student>().FindAsync(id);
            return View(data);
        }
    }
}

