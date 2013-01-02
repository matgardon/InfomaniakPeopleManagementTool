using System;

namespace InfomaniakPeopleManagementTool.Model.Interface
{
    public interface IPerson : IEquatable<IPerson>, IComparable<IPerson>
    {
        /// <summary>
        /// unique ID of this person.
        /// 0 means this person doesn't yet have an ID.
        /// This property cannot be negative.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Name of this person.
        /// This property cannot be null or empty.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Family name of this person.
        /// This property cannot be null or empty.
        /// </summary>
        string LastName { get; set; }
    }
}