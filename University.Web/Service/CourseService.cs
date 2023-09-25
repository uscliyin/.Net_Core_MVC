using Microsoft.EntityFrameworkCore.Metadata.Internal;
using University.Web.Data;
using University.Web.Models;
using University.Web.Models.ViewModels;
using University.Web.Repository;

namespace University.Web.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;
        public CourseService(ICourseRepository repo) {
            _repo = repo;
        }
        public async Task<bool> AddOneCourse(CourseViewModel obj)
        {
            var course = new Course()
            {
                Id = obj.Id,
                CourseName = obj.CourseName,
                CourseDescription = obj.CourseDescription

            };

            await _repo.AddAsync(course);
            return true;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            bool deletedResult = await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<CourseViewModel>> GetAllCourse()
        {
            var courseLists = await _repo.GetAllAsync();
            var courseViewModel = new List<CourseViewModel>();
            foreach (var course in courseLists)
            {
                courseViewModel.Add(new CourseViewModel
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    CourseDescription = course.CourseDescription,
                });
            }
            return courseViewModel;
        }

        public async Task<CourseViewModel> GetOneCourseById(int id)
        {
            var courseObj = await _repo.GetAsync(id);
            var courseModelView = new CourseViewModel()
            {
                Id = id,
                CourseName = courseObj.CourseName,
                CourseDescription = courseObj.CourseDescription,
            };
            return courseModelView;
        }

        public async Task<bool> UpdateCourse(CourseViewModel obj)
        {
            var course = new Course()
            {
                Id = obj.Id,
                CourseName = obj.CourseName,
                CourseDescription = obj.CourseDescription

            };
            await _repo.UpdateAsync(course);
            return true;
            
        }
    }
}
