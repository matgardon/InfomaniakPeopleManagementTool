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
        /// County to which this campus' city belongs.
        /// This property cannot be null or empty.
        /// </summary>
        string County { get; }

        /// <summary>
        /// Maximum number of students for this campus.
        /// If set to 0, this campus has an infinite capacity.
        /// This property cannot be negative.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// List of students belonging to this campus.
        /// </summary>
        IEnumerable<IStudent> Students { get; }

        /// <summary>
        /// List of Teachers belonging to this campus.
        /// </summary>
        IEnumerable<ITeacher> Teachers { get; } 

        bool AddStudent(IStudent student);
        bool RemoveStudent(IStudent student);

        bool AddTeacher(ITeacher teacher);
        bool RemoveTeacher(ITeacher teacher);

        bool SetTeacherSalary(ITeacher teacher, int newSalary);

        bool SetInternalTeachersSalary(int newSalary);

    }
}