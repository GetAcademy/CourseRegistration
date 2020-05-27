using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseRegistration.Core.DomainModel
{
    public class Course
    {
        private readonly List<Student> _registrations;
        public int Capacity { get; }
        public string Name { get; }
        public Guid Id { get; }

        public IEnumerable<Student> Registrations => _registrations;

        public Course(Guid id, int capacity, string name, IEnumerable<Student> students = null)
        {
            Id = id;
            _registrations = new List<Student>();
            Capacity = capacity;
            Name = name;
            if (students != null) _registrations.AddRange(students);
        }

        public void Register(Student student)
        {
            if (_registrations.Any(r => r.Email == student.Email))
                throw new ApplicationException("402 - Allerede påmeldt.");
            if (_registrations.Count >= Capacity)
                throw new ApplicationException("403 - Ikke flere plasser.");
            _registrations.Add(student);
        }
    }
}