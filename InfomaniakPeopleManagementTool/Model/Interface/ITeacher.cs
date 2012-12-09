namespace InfomaniakPeopleManagementTool.Model.Interface
{
    public interface ITeacher : IPerson
    {
        /// <summary>
        /// The professor's salary.
        /// This property cannot be negative or null.
        /// </summary>
        int Salary { get; set; }

        /// <summary>
        /// Boolean used to know if this professor is internal to the campus or external.
        /// </summary>
        bool IsInternal { get; set; }
    }
}