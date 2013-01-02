using System;
using InfomaniakPeopleManagementTool.Model.Interface;

namespace InfomaniakPeopleManagementTool.Model
{
    public abstract class Person : IPerson
    {
        private int id;
        private readonly string firstName;
        private readonly string lastName;

        public int Id
        {
            get { return this.id; }
            set
            {
                if (Equals(this.id, value)) return;

                if (value <= 0)
                    throw new NotSupportedException("id cannot be negative or null");

                this.id = value;
            }
        }

        public string FirstName { get { return this.firstName; } }

        public string LastName { get { return this.lastName; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="id"></param>
        protected Person(string firstName, string lastName, int id)
        {
            if (String.IsNullOrEmpty(firstName))
                throw new ArgumentNullException("firstName");

            if (String.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("lastName");

            if (id < 0)
                throw new ArgumentException("id should not be negative");

            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
        }

        public int CompareTo(IPerson other)
        {
            if (this.Id < other.Id) return -1;

            return this.Id > other.Id ? 1 : 0; 
            // If ids are both 0 (no id for students), then no guidelines are given => equals. 
            // But we could consider sorting them by their family names if needed.
        }

        public bool Equals(IPerson other)
        {
            if (this.Id == 0 && other.Id == 0)// If both students have no ID, we compare on their first & last name.
                return (this.FirstName.Equals(other.FirstName) && this.LastName.Equals(other.LastName));

            return this.Id == other.Id;
        }

        public override string ToString()
        {
            return "Id: " + this.id + " firstName: " + this.firstName + " lastName: " + this.lastName;
        }
    }
}
