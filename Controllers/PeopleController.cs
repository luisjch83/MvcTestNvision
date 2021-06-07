using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTestNvision.Models.DB;
using MvcTestNvision.Utilities;

namespace MvcTestNvision.Controllers
{
    public class PeopleController : Controller
    {
        private readonly nvisionTestContext _context;

        public PeopleController(nvisionTestContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            return View(await _context.People.ToListAsync());
        }

        // GET: Person get details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .FirstOrDefaultAsync(m => m.IdPerson == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Person/Create or Edit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Person());
            else
                return View(_context.People.Find(id));            
        }

        // POST: Person/Create or Edit        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdPerson,Titulo,Nombre,Apellido,Telefono,Direccion")] MvcTestNvision.Models.DB.Person person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (person.IdPerson == 0)
                        _context.Add(person);
                    else
                        _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    //This either returns a error string, or null if it can’t handle that error
                    var error = e;
                    if (error != null)
                    {
                        return (IActionResult)error; //return the error string
                    }
                    throw; //couldn’t handle that error, so rethrow
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // Save form Data in Json file in  C://
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveJson([Bind("IdPerson,Titulo,Nombre,Apellido,Telefono,Direccion")] MvcTestNvision.Models.DB.Person person)
        {
            if (ModelState.IsValid)
            {
                MvcTestNvision.Utilities.Utilities util = new MvcTestNvision.Utilities.Utilities();
                util.ExportJson(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // Save form Data in Xml file in  C://
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveXml([Bind("IdPerson,Titulo,Nombre,Apellido,Telefono,Direccion")] MvcTestNvision.Models.DB.Person person)
        {
            if (ModelState.IsValid)
            {
                MvcTestNvision.Utilities.Utilities util = new MvcTestNvision.Utilities.Utilities();
                util.ExportXML(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // Delete Person
        public async Task<IActionResult> Delete(int? id)
        {
            var person = await _context.People.FindAsync(id);
            try
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                //This either returns a error string, or null if it can’t handle that error
                var error = e;
                if (error != null)
                {
                    return (IActionResult)error; //return the error string
                }
                throw; //couldn’t handle that error, so rethrow
            }           
            return RedirectToAction(nameof(Index));
        }
    }
}
