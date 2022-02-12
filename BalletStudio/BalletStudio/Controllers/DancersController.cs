using BalletStudio.Data;
using BalletStudio.Data.Models;
using BalletStudio.Models.Dancers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BalletStudio.Controllers
{
    public class DancersController : Controller
    {
        private readonly BalletStudioDbContext data;

        public DancersController(BalletStudioDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddDancerFormModel
        {
            Teachers = this.GetTeachers()
        });

        [HttpPost]
        public IActionResult Add(AddDancerFormModel dancer)
        {
            if (!ModelState.IsValid)
            {
                dancer.Teachers = this.GetTeachers();

                return View(dancer);
            }
            var dancerData = new Dancer
            {
                FirstName = dancer.FirstName,
                LastName = dancer.LastName,
                Age = dancer.Age,
                TeacherId = dancer.TeacherId,
                GroupId =0
            };

            this.data.Dancers.Add(dancerData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<TeacherNameFormModel> GetTeachers()
        {
            return this.data
                .Teachers
                .Select(t => new TeacherNameFormModel
                {
                    Id = t.Id,
                    FullName = t.FirstName +" " + t.LastName,
                })
                .ToList();
        }
    }

}
