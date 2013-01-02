using System;
using System.Collections.Generic;
using System.Linq;
using InfomaniakPeopleManagementTool.Model.Interface;
using InfomaniakPeopleManagementTool.Model.Utilities;

namespace InfomaniakPeopleManagementTool.Model
{
    public class Campus : ICampus, IEquatable<ICampus>
    {
        #region fields
        
        private string city;
        private string region;
        private int capacity;

        //We use sortedSet for lists of students and teachers : this enables us to guarantee two things :
        //
        //- First, each person in those lists are unique as a Set can only accept unique element (implemented by Iequatable on IPerson). 
        //This means that we cannot have an unstable situation with a student or a teacher registered twice in this campus.
        //
        //- Second, those sets are always sorted upon insertion and removal due to their implementation. 
        //So the condition on the list of students to be sorted is guaranteed at all times (as IPerson implements IComparable)
        private SortedSet<Student> students;
        private SortedSet<Teacher> teachers;

        #endregion

        #region properties

        public string City { get { return this.city; } set { this.city = value; } }

        public string Region { get { return this.region; } set { this.region = value; } }

        public int Capacity { get { return this.capacity; } set { throw new NotImplementedException("Capacity modification not supported");} }
        // TODO set on capacity is not implemented because it would need a deeper validation : 
        // if the capacity is reduced, constraints on the current number of students should be validated,
        // and possible actions should be taken (deleting students ? not setting new capacity ?). 
        // As these constraints are not defined in the specifications, it has been currently decided that the set throws an exception.

        // Exposed fields are used for Xml serialization, hence they have read & write access (for deserialization).
        // TODO this exposes the list of students as a modifiable, while we don't want this behavior (getStudents returns a read-only collection). 
        // The solution is for the Campus class to implement IXmlSerializable, which is too troublesome for this small project but should be done for fiability of the model.
        public List<Student> Students { get { return this.students.ToList(); } set { this.students = new SortedSet<Student>(value); }}
        public List<Teacher> Teachers { get { return this.teachers.ToList(); } set { this.teachers = new SortedSet<Teacher>(value); } }

        #endregion

        #region ctor

        // only used for serialization
        private Campus() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="region"></param>
        /// <param name="capacity"></param>
        public Campus(string city, string region, int capacity = 0)
        {
            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException("city");
            if (string.IsNullOrEmpty(region))
                throw new ArgumentNullException("region");
            if (capacity < 0)
                throw new ArgumentException("capacity cannot be negative");

            this.city = city;
            this.region = region;
            this.capacity = capacity;

            this.students = new SortedSet<Student>();
            this.teachers = new SortedSet<Teacher>();
        }

        #endregion

        #region model related methods

        public IReadOnlyCollection<IStudent> GetStudents()
        {
            return this.students.ToList().AsReadOnly();
        }

        public IReadOnlyCollection<ITeacher> GetTeachers()
        {
            return this.teachers.ToList().AsReadOnly();
        }

        public bool AddStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException("student");

            if (this.students.Contains(student)) return false;

            //Exception is thrown after cheking if the student is already present to prevent throwing exception uselessly.
            if (this.students.Count > this.capacity && this.capacity > 0)
                throw new FullCampusException("Campus has reached maximum capacity");

            return this.students.Add(student);
        }

        public bool RemoveStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException("student");

            return this.students.Contains(student) && this.students.Remove(student);
        }

        public bool AddTeacher(Teacher teacher)
        {
            if (teacher == null) throw new ArgumentNullException("teacher");

            return !this.teachers.Contains(teacher) && this.teachers.Add(teacher);
        }

        public bool RemoveTeacher(Teacher teacher)
        {
            if (teacher == null) throw new ArgumentNullException("teacher");

            return this.teachers.Contains(teacher) && this.teachers.Remove(teacher);
        }

        public bool SetTeacherSalary(Teacher teacher, int newSalary)
        {
            if (teacher == null)
                throw new ArgumentNullException("teacher");
            if (newSalary <= 0)
                throw new ArgumentException("Salary cannot be negative or null");

            var target = this.teachers.Single(p => p.Id == teacher.Id);
            //Single throws exception if there is more than one teacher with this id.
            //This should never arrive as we use a SortedSet (unique elements) for the list of teachers and the Teacher class implements IEquatable.
            //Hence, raising an exception here makes sense as it is a bug.

            if (target == null || target.IsInternal) return false;

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

        public bool Equals(ICampus other)
        {
            return this.City.Equals(other.City) && this.Region.Equals(other.Region);
        }

        public override string ToString()
        {
            return "City : "+this.city+" Region: "+this.region+" Capacity: "+this.capacity;
        }
    }
}