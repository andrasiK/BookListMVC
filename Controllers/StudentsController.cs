﻿using System;
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

        //GET Students/Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id== null)
            {
                return NotFound();
            }

            var student = await _db.Students.FirstOrDefaultAsync(m => m.ID == id);
                if (student == null)
                { 
                 return NotFound();
                }
            return View(student);
        }

        //POST: Students/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var studentFromDb = await _db.Students.FindAsync(id);
            _db.Students.Remove(studentFromDb);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        //GET: Students/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(u => u.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);  
        }

        //POST: Students/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit()
        {
            if (ModelState.IsValid)
            {
                _db.Update(Student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Student);
        }
            
    }
}
