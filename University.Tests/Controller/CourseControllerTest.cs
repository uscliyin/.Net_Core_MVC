using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Web.Controllers;
using University.Web.Models.ViewModels;
using University.Web.Service;

namespace University.Tests.Controller
{
    [TestClass]
    public class CourseControllerTest
    {
        private Mock<ICourseService> _courseServiceMock;
        private CourseController _courseController;
        public CourseControllerTest()
        {
            _courseServiceMock=new Mock<ICourseService>();
            _courseController = new CourseController(_courseServiceMock.Object);
        }

        [TestMethod]
        public async Task CourseController_Index_ReturnViewWithCourses()
        {
            //Arrange
            var mockCourses = new List<CourseViewModel>{
                new CourseViewModel { CourseName = "Math", CourseDescription = "good" },
            };
            _courseServiceMock.Setup(service => service.GetAllCourse()).ReturnsAsync(mockCourses);


            //Act
            var result=await _courseController.Index();

            //
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            var model=viewResult.Model as IEnumerable<CourseViewModel>;
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Count());
           

        }

        [TestMethod]

        public async Task Create_ModelStateValid_RedirectToHomeIndex()
        {
            //Arrange

            var course = new CourseViewModel { CourseName = "javascript", CourseDescription = "bad" };

            _courseServiceMock.Setup(service => service.AddOneCourse(course)).ReturnsAsync(true);

            //Act

            var result=await _courseController.Create(course) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Course", result.ControllerName);

        }

        [TestMethod]
        public async Task Create_InvalidCourse_ReturnsView()
        {
            // Arrange
            var courseViewModel = new CourseViewModel { CourseName = "", CourseDescription = "" };
            _courseController.ModelState.AddModelError("TestError", "Test error message"); // Manually adding a model error

            // Act
            var result = await _courseController.Create(courseViewModel) as ViewResult;

            // Assert
            _courseServiceMock.Verify(service => service.AddOneCourse(courseViewModel), Times.Never);
            Assert.IsNotNull(result);
        }


    }
}
