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
    }
}
