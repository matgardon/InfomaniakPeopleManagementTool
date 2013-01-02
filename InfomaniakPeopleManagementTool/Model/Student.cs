using System;
using InfomaniakPeopleManagementTool.Model.Interface;

namespace InfomaniakPeopleManagementTool.Model
{
    public class Student : Person, IStudent
    {
        /// <summary>
        /// Create a student which already has an ID.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="id"></param>
        public Student(string firstName, string lastName, int id) : base(firstName,lastName,id)
        {}

        /// <summary>
        /// Create a student without an ID yet.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Student(string firstName, string lastName): base(firstName, lastName,0)
        {}

        public override string ToString()
        {
            return "Student - " + base.ToString();
        }
    }
}