using System;
using System.Runtime.Serialization;

namespace InfomaniakPeopleManagementTool.Model.Utilities
{
    [Serializable]
    public class FullCampusException : Exception
    {
        public FullCampusException()
        {}

        public FullCampusException(string message):base(message)
        {}

        public FullCampusException(string message,
      Exception innerException)
            : base(message, innerException)
        {}

        protected FullCampusException(SerializationInfo info,
      StreamingContext context)
            : base(info, context)
        {}
    }
}
