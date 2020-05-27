using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseRegistration.Core.DomainModel
{
    public class Course
    {
        private readonly List<Student> _registrations;
        private readonly int _capacity;
        private readonly string _name;

        public Course(int capacity, string name)
        {
            _registrations = new List<Student>();
            _capacity = capacity;
            _name = name;
        }

        public void Register(Student student)
        {
            if (_registrations.Any(r => r.Email == student.Email))
                throw new ApplicationException("402 - Allerede påmeldt.");
            if (_registrations.Count >= _capacity)
                throw new ApplicationException("403 - Ikke flere plasser.");
            _registrations.Add(student);
        }
    }
}