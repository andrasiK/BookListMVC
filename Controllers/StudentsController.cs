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

        public async Task <IActionResult> Index()
        {
            return View(await _db.Students.ToListAsync());
        }
    }
}
