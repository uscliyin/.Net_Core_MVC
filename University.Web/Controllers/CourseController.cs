using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Web.Data;
using University.Web.Models;
using University.Web.Models.ViewModels;
using University.Web.Repository;
using University.Web.Service;

namespace University.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            var courses=await _courseService.GetAllCourse();
            return View(courses);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseViewModel obj)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Create Course Successfully";
                await _courseService.AddOneCourse(obj);
                return RedirectToAction("Index", "Course");
            }
            else
            {
                return View();
            }
            
  
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var courseObj = await _courseService.GetOneCourseById(id);

            if (courseObj == null)
            {
                return NotFound();
            }
            
            return View(courseObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseViewModel obj)
        {
            bool updateResult = await _courseService.UpdateCourse(obj);
            if (updateResult)
            {
                TempData["success"] = "Update Course Successfully";
                return RedirectToAction("Index", "Course");
            }
            else
            {
                return View();
            }
            
        }


        public async Task<IActionResult> Delete(int id)
        {
            bool deletedResult = await _courseService.DeleteCourse(id);
            if (deletedResult == true)
            {
                TempData["success"] = "Delete Course Successfully";
                return RedirectToAction("Index", "Course");
            }
            else
            {
                return View();
            }
            
        }

    }
}
