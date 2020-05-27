using System;
using CourseRegistration.Core.DomainModel;

namespace CourseRegistration.Core.DomainService
{
    public interface ICourseRepository
    {
        Course GetById(Guid registrationCourseId);
        void Update(Course course);
    }
}
