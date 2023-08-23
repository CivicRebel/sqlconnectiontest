using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using sqlconnectiontest.Models;
using sqlconnectiontest.Services;

namespace sqlconnectiontest.Controllers
{
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

        // The Index method is used to get a list of courses and return it to the view
        public IActionResult Index()
        {
            Abc();
            IEnumerable<Course> _course_list = _course_service.GetCourses(_configuration.GetConnectionString("SQLConnection"));
            return View(_course_list);
        }

        public async void Abc()
        {
            if (await _featureManager.IsEnabledAsync("enableFeature"))
            {
                ViewData["abc"] = _configuration["sampleapp:testkey"];
            }
        }
    }
}
