using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class LeaveEvent 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// Date for this leave event.
        /// </summary>
        public DateTime? eventDate { get; set; }

        /// <summary>
        /// The code describing the type of leave taken, for example:  Sick  Personal  Vacation
        /// </summary>
        public string categoryType { get; set; }

        /// <summary>
        /// Expanded reason for the staff leave.
        /// </summary>
        public string reason { get; set; }

        /// <summary>
        /// The hours the staff was absent, if not the entire working day.
        /// </summary>
        public double? hoursOnLeave { get; set; }

        /// <summary>
        /// Indicator of whether a substitute was assigned during the period of staff leave.
        /// </summary>
        public bool? substituteAssigned { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

