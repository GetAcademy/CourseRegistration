using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CourseRegistration.Core.DomainModel;
using CourseRegistration.Core.DomainService;

namespace CourseRegistration.Infrastructure.DataAccess
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IPathRepository _pathRepository;

        public CourseRepository(IPathRepository pathRepository)
        {
            _pathRepository = pathRepository;
        }
        public Course GetById(Guid courseId)
        {
            var basePath = _pathRepository.AppPath;
            var fileNames = Directory.GetFiles(basePath);
            var fileName = fileNames.SingleOrDefault(fn => fn.Contains(courseId.ToString()));
            if (fileName == null) throw new ApplicationException("401 - Fant ikke kurs.");
            var courseParts = fileName.Split(@"\").Last().Split(new[] { '_', '.' });
            var capacity = Convert.ToInt32(courseParts[2]);
            var id = courseParts[0];
            var name = courseParts[1];
            var emails = File.ReadAllLines(fileName);
            var students = emails.Select(email => new Student(email));
            return new Course(new Guid(id), capacity, name, students);
        }

        public void Update(Course course)
        {
            var fileName = course.Id + "_" + course.Name + "_" + course.Capacity + ".txt";
            var registrationEmails = course.Registrations.Select(r=>r.Email);
            File.WriteAllLines(_pathRepository.AppPath + @"\" + fileName, registrationEmails);
        }
    }
}
