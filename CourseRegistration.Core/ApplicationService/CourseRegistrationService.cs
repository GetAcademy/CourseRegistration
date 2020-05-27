using System;
using System.Collections.Generic;
using System.Text;
using CourseRegistration.Core.DomainModel;
using CourseRegistration.Core.DomainService;

namespace CourseRegistration.Core.ApplicationService
{
    public class CourseRegistrationService
    {
        private readonly ICourseRepository _courseRespository;

        public CourseRegistrationService(ICourseRepository courseRespository)
        {
            _courseRespository = courseRespository;
        }

        public void CreateRegistration(Registration registration)
        {
            var course = _courseRespository.GetById(registration.CourseId);
            if (course == null) throw new ApplicationException("401 - Fant ikke kurs.");
            var student = new Student(registration.StudentEmail);
            course.Register(student);
            _courseRespository.Update(course);
        }
    }
}
