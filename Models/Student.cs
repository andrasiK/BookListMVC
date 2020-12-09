using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace BookListMVC.Models
{
    public class Student
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string School { get; set; }
    }
}
