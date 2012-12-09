using System;
using InfomaniakPeopleManagementTool.Model.Interface;

namespace InfomaniakPeopleManagementTool.Model
{
    public class Teacher : Person, ITeacher
    {
        private int salary;

        private bool isInternal;

        public int Salary
        {
            get { return this.salary; }
            set
            {
                if (Equals(this.salary, value)) return;

                if (value <= 0)
                    throw new NotSupportedException("salary cannot be negative or null");

                this.salary = value;
            }
        }

        public bool IsInternal
        {
            get { return this.isInternal; }
            set { this.isInternal = value; }
        }

        public Teacher(string firstName, string lastName, int id, int salary, bool isInternal = true)
            : base(firstName, lastName, id)
        {
            if (salary <= 0)
                throw new ArgumentException("a Teacher's salary cannot be negative or null (have some respect dude!)");

            this.salary = salary;
            this.isInternal = isInternal;
        }
    }
}