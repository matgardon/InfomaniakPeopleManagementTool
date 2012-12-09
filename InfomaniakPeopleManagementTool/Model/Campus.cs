using System;
using System.Collections.Generic;
using System.Linq;
using InfomaniakPeopleManagementTool.Model.Interface;
using InfomaniakPeopleManagementTool.Model.Utilities;

namespace InfomaniakPeopleManagementTool.Model
{
    public class Campus : ICampus
    {
        #region fields
        
        private readonly string city;
        private readonly string county;
        private readonly int capacity;

        private readonly SortedSet<IStudent> students;
        private readonly SortedSet<ITeacher> teachers;

        #endregion

        #region properties

        public string City { get { return this.city; } }

        public string County { get { return this.county; } }

        public int Capacity { get { return this.capacity; } }

        public IEnumerable<IStudent> Students { get { return this.students; } }
        public IEnumerable<ITeacher> Teachers { get { return this.teachers; } }

        #endregion

        #region ctor

        public Campus(string city, string county, int capacity = 0)
        {
            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException("city");
            if (string.IsNullOrEmpty(county))
                throw new ArgumentNullException("county");
            if (capacity < 0)
                throw new ArgumentException("capacity cannot be negative");

            this.city = city;
            this.county = county;
            this.capacity = capacity;

            this.students = new SortedSet<IStudent>();
            this.teachers = new SortedSet<ITeacher>();
        }

        #endregion

        #region methods

        public bool AddStudent(IStudent student)
        {
            if (student == null)
                throw new ArgumentNullException("student");

            if (this.students.Contains(student)) return false;

            if (this.students.Count > this.capacity && this.capacity > 0)
                throw new FullCampusException("Campus has reached maximum capacity");

            this.students.Add(student);
            return true;
        }

        public bool RemoveStudent(IStudent student)
        {
            if (student == null)
                throw new ArgumentNullException("student");

            if (!this.students.Contains(student)) return false;

            this.students.Remove(student);
            return true;
        }

        public bool AddTeacher(ITeacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException("teacher");

            if (this.teachers.Contains(teacher)) return false;

            this.teachers.Add(teacher);
            return true;
        }

        public bool RemoveTeacher(ITeacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException("teacher");

            if (!this.teachers.Contains(teacher)) return false;

            this.teachers.Add(teacher);
            return true;
        }

        public bool SetTeacherSalary(ITeacher teacher, int newSalary)
        {
            if (teacher == null)
                throw new ArgumentNullException("teacher");
            if (newSalary <= 0)
                throw new ArgumentException("Salary cannot be negative or null");

            var target = this.teachers.Single(p => p.Id == teacher.Id);

            if (target == null) return false;

            if (target.IsInternal) return false;//TODO change that control and make this method's signature use only a custom type for internal Teachers

            target.Salary = newSalary;
            return true;
        }

        public bool SetInternalTeachersSalary(int newSalary)
        {
            if (newSalary <= 0)
                throw new ArgumentException("Salary cannot be negative or null");

            var internalProfessors = this.teachers.Where(p => p.IsInternal).ToList();

            if (!internalProfessors.Any()) return false;

            foreach (var internalProfessor in internalProfessors)
                internalProfessor.Salary = newSalary;

            return true;
        }

        #endregion
    }
}