using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using sqlconnectiontest.Models;
using sqlconnectiontest.Services;

namespace sqlconnectiontest.Controllers
{
    [ApiController]
    [Route("/api/Course")]
    public class CourseController : Controller
    {
        private readonly CourseService _course_service;
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _featureManager;

        public CourseController(CourseService _svc, IConfiguration config, IFeatureManager featureManager)
        {
            _course_service = _svc;
            _configuration = config;
            _featureManager = featureManager;
        }

        
        [HttpGet]
        [Route("")]
        public IActionResult GetCourses()
        {
            return Ok(_course_service.GetCourses(_configuration.GetConnectionString("SQLConnection")));
        }
    }
}
