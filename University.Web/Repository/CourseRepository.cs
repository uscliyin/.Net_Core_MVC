using University.Web.Data;
using University.Web.Models;

namespace University.Web.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(UniversityDbContext db) : base(db)
        {
        }
    }
}
