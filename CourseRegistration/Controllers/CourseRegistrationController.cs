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
        private readonly IWebHostEnvironment _env;

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

        [HttpPut]
        public ActionResult RegisterCourse([FromBody]Registration registration)
        {
            var basePath = _env.ContentRootPath + @"\bin\Debug\netcoreapp3.1\courses";
            var fileNames = Directory.GetFiles(basePath);
            var fileName = fileNames.SingleOrDefault(fn => fn.Contains(registration.CourseId.ToString()));
            if (fileName == null) return StatusCode(401, "Fant ikke kurs.");
            var courseParts = fileName.Split(@"\").Last().Split(new []{'_', '.'});
            var capacity = Convert.ToInt32(courseParts[2]);
            var registrations = System.IO.File.ReadAllLines(fileName);
            if (registrations.Contains(registration.StudentEmail)) return StatusCode(402, "Allerede påmeldt.");
            if (registrations.Length >= capacity) return StatusCode(403, "Ikke flere plasser.");
            System.IO.File.AppendAllText(fileName, registration.StudentEmail + "\n");
            return Ok();
        }

        public class Registration
        {
            public Guid CourseId { get; set; }
            public string StudentEmail { get; set; }
        }
    }
}
