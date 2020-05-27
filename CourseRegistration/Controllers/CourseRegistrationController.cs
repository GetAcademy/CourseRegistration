using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRegistrationController : ControllerBase
    {
        private IWebHostEnvironment _env;

        public CourseRegistrationController(IWebHostEnvironment env)
        {
            _env = env;
        }
        [HttpGet]
        public ActionResult GetAllCourses()
        {
            var data = Directory
                .GetFiles(_env.ContentRootPath + @"\bin\Debug\netcoreapp3.1\courses")
                .Select(fileName => fileName.Split("_"))
                .Select(fileNameParts => new
                {
                    Id = fileNameParts[0],
                    Name = fileNameParts[1],
                    Capacity = fileNameParts[2],
                });
            return Ok(data);
        }
    }
}
