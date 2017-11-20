namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentCompetencyObjective 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related CompetencyObjective resource.
        /// </summary>
        public CompetencyObjectiveReference objectiveCompetencyObjectiveReference { get; set; }

        /// <summary>
        /// A reference to the related GradingPeriod resource.
        /// </summary>
        public GradingPeriodReference gradingPeriodReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// A reference to the related StudentProgramAssociation resource.
        /// </summary>
        public StudentProgramAssociationReference studentProgramAssociationReference { get; set; }

        /// <summary>
        /// A reference to the related StudentSectionAssociation resource.
        /// </summary>
        public StudentSectionAssociationReference studentSectionAssociationReference { get; set; }

        /// <summary>
        /// The competency level assessed for the student for the referenced learning objective.
        /// </summary>
        public string competencyLevelDescriptor { get; set; }

        /// <summary>
        /// A statement provided by the teacher that provides information in addition to the grade or assessment score.
        /// </summary>
        public string diagnosticStatement { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

