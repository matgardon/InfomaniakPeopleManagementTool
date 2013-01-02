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

        // This could be an auto-property, but in a real application, it is supposed to evolve 
        // so that an external teacher can become an internal one and vice-versa. 
        // That's why this stays as a normal property with a backing private field.
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

        public override string ToString()
        {
            return "Teacher - "+base.ToString()+" Salary: "+this.salary+" IsInternal: "+this.isInternal;
        }
    }
}