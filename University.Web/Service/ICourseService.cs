using University.Web.Models.ViewModels;

namespace University.Web.Service
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseViewModel>> GetAllCourse();
        Task<CourseViewModel> GetOneCourseById(int id);
        Task<bool> AddOneCourse(CourseViewModel obj);
        Task<bool> UpdateCourse(CourseViewModel obj);
        Task<bool> DeleteCourse(int id);
    }
}
