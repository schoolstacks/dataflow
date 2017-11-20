namespace DataFlow.EdFi.Models.EnrollmentComposite 
{
    public class Student_studentTelephone 
    {
        /// <summary>
        /// Key for TelephoneNumber
        /// </summary>
        public string telephoneNumberType { get; set; }

        /// <summary>
        /// The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.
        /// </summary>
        public int? orderOfPriority { get; set; }

        /// <summary>
        /// The telephone number including the area code, and extension, if applicable.
        /// </summary>
        public string telephoneNumber { get; set; }

        }
}

