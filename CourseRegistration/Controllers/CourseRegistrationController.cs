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
            try
            {
                var registration = new Registration
                {
                    CourseId = registrationViewModel.CourseId,
                    StudentEmail = registrationViewModel.StudentEmail
                };
                _courseRegistrationService.CreateRegistration(registration);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return StatusCode(401, e.Message);
            }
        }

        public class RegistrationViewModel
        {
            public Guid CourseId { get; set; }
            public string StudentEmail { get; set; }
        }
    }
}
;