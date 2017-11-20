namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentInterventionAssociationInterventionEffectiveness 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string diagnosisDescriptor { get; set; }

        /// <summary>
        /// Key for PopulationServed
        /// </summary>
        public string populationServedType { get; set; }

        /// <summary>
        /// Key for GradeLevel
        /// </summary>
        public string gradeLevelDescriptor { get; set; }

        /// <summary>
        /// Along a percentile distribution of students, the improvement index represents the change in an average student's percentile rank that is considered to be due to the intervention.
        /// </summary>
        public int? improvementIndex { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string interventionEffectivenessRatingType { get; set; }

        }
}

