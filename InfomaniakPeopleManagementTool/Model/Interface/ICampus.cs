using System.Collections.Generic;

namespace InfomaniakPeopleManagementTool.Model.Interface
{
    public interface ICampus
    {
        /// <summary>
        /// City in which this campus is implanted.
        /// This property cannot be null or empty.
        /// </summary>
        string City { get; }

        /// <summary>
        /// Region to which this campus' city belongs.
        /// This property cannot be null or empty.
        /// </summary>
        string Region { get; }

        /// <summary>
        /// Maximum number of students for this campus.
        /// If set to 0, this campus has an infinite capacity.
        /// This property cannot be negative.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Retrieves a Read-only version of the list of students.
        /// </summary>
        /// <returns></returns>
        IReadOnlyCollection<IStudent> GetStudents();
        /// <summary>
        /// Retrieves a Read-only version of the list of teachers (both internal & external).
        /// </summary>
        /// <returns></returns>
        IReadOnlyCollection<ITeacher> GetTeachers(); 
        
        /// <summary>
        /// Add a student (with or without ID) to this campus.
        /// This method throws a FullCampusException if the limit capacity is already reached before adding a student to this campus.
        /// </summary>
        /// <param name="student"> must be non-null. Otherwise, throws an ArgumentNullException.</param>
        /// <returns>true if the student was correctly added. false if the student was already present.</returns>
        bool AddStudent(Student student);

        /// <summary>
        /// Remove a student (with or without ID) from this campus.
        /// </summary>
        /// <param name="student"> must be non-null. Otherwise, throws an ArgumentNullException.</param>
        /// <returns>true if the student was correctly removed. false if the student was not found in this campus.</returns>
        bool RemoveStudent(Student student);

        /// <summary>
        /// Add a teacher (internal or external) to this campus.
        /// </summary>
        /// <param name="teacher">must be non-null. Otherwise, throws an ArgumentNullException.</param>
        /// <returns>true if the teacher was correctly added. false if the teacher was already present.</returns>
        bool AddTeacher(Teacher teacher);

        /// <summary>
        /// Remove a teacher (internal or external) from this campus.
        /// </summary>
        /// <param name="teacher">must be non-null. Otherwise, throws an ArgumentNullException.</param>
        /// <returns>true if the teacher was correctly removed. false if the teacher was not found in this campus.</returns>
        bool RemoveTeacher(Teacher teacher);

        /// <summary>
        /// Set a salary for an external teacher. returns false if the teacher is internal.
        /// Throws Exception if two teachers with the same id as the given parameter are found in this campus.
        /// </summary>
        /// <param name="teacher">must be non-null. Otherwise, throws an ArgumentNullException.</param>
        /// <param name="newSalary"> must be > 0. Otherwise, throws an ArgumentException.</param>
        /// <returns>True if the teacher's salary was correctly set. False if the teacher was not found on this campus or if the teacher is internal.</returns>
        bool SetTeacherSalary(Teacher teacher, int newSalary);

        /// <summary>
        /// Set the salary for all internal teachers.
        /// </summary>
        /// <param name="newSalary">must be > 0. Otherwise, throws an ArgumentException.</param>
        /// <returns>True if each internal teachers' salary was set to newSalary. False if no internal teachers were found in this campus.</returns>
        bool SetInternalTeachersSalary(int newSalary);

    }
}