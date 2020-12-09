using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListMVC.Controllers
{
    public class StudentsController : Controller
    {
        // DB

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Student Student { get; set; }

        public StudentsController(ApplicationDbContext db)
        {
            _db = db;
        }

       
       // GET: Students
        
        public async Task <IActionResult> Index()
        {
            return View(await _db.Students.ToListAsync());
        }

        
        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Students/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

    }
}
