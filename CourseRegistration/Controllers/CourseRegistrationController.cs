using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CourseRegistration.Core.ApplicationService;
using CourseRegistration.Core.DomainModel;
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
        private readonly CourseRegistrationService _courseRegistrationService;

        public CourseRegistrationController(IWebHostEnvironment env, CourseRegistrationService courseRegistrationService)
        {
            _courseRegistrationService = courseRegistrationService;
            _env = env;
        }

        [HttpPut]
        public ActionResult RegisterCourse([FromBody]RegistrationViewModel registrationViewModel)
        {
            var registration = new Registration
            {
                CourseId =  registrationViewModel.CourseId,
                StudentEmail = registrationViewModel.StudentEmail
            };
            _courseRegistrationService.CreateRegistration(registration);

            //var basePath = _env.ContentRootPath + @"\bin\Debug\netcoreapp3.1\courses";
            //var fileNames = Directory.GetFiles(basePath);
            //var fileName = fileNames.SingleOrDefault(fn => fn.Contains(registrationViewModel.CourseId.ToString()));
            //if (fileName == null) return StatusCode(401, "Fant ikke kurs.");
            //var courseParts = fileName.Split(@"\").Last().Split(new []{'_', '.'});
            //var capacity = Convert.ToInt32(courseParts[2]);
            //var registrations = System.IO.File.ReadAllLines(fileName);
            //if (registrations.Contains(registrationViewModel.StudentEmail)) return StatusCode(402, "Allerede påmeldt.");
            //if (registrations.Length >= capacity) return StatusCode(403, "Ikke flere plasser.");
            //System.IO.File.AppendAllText(fileName, registrationViewModel.StudentEmail + "\n");
            return Ok();
        }

        public class RegistrationViewModel
        {
            public Guid CourseId { get; set; }
            public string StudentEmail { get; set; }
        }
    }
}
