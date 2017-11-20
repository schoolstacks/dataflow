namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentParentAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Parent resource.
        /// </summary>
        public ParentReference parentReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// The nature of an individual''s relationship to a student; for example:  Father  Mother  Step Father  Step Mother  Foster Father  Foster Mother  Guardian  ...  NEDM: Relationship to Student
        /// </summary>
        public string relationType { get; set; }

        /// <summary>
        /// Indicator of whether the person is a primary parental contact for the Student.
        /// </summary>
        public bool? primaryContactStatus { get; set; }

        /// <summary>
        /// Indicator of whether the Student lives with the associated parent.
        /// </summary>
        public bool? livesWith { get; set; }

        /// <summary>
        /// Indicator of whether the person is a designated emergency contact for the Student.
        /// </summary>
        public bool? emergencyContactStatus { get; set; }

        /// <summary>
        /// The numeric order of the preferred sequence or priority of contact.
        /// </summary>
        public int? contactPriority { get; set; }

        /// <summary>
        /// Restrictions for student and/or teacher contact with the individual (e.g., the student may not be picked up by the individual).
        /// </summary>
        public string contactRestrictions { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

