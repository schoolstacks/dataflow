using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class GradebookEntry 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related GradingPeriod resource.
        /// </summary>
        public GradingPeriodReference gradingPeriodReference { get; set; }

        /// <summary>
        /// A reference to the related Section resource.
        /// </summary>
        public SectionReference sectionReference { get; set; }

        /// <summary>
        /// The name or title of the activity to be recorded in the gradebook entry.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The date the assignment, homework, or assessment was assigned or executed.
        /// </summary>
        public DateTime? dateAssigned { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// A detailed description of the entity.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// An unordered collection of gradebookEntryLearningObjectives.  Learning Objectives associated with the Gradebook Entry.
        /// </summary>
        public List<GradebookEntryLearningObjective> learningObjectives { get; set; }

        /// <summary>
        /// An unordered collection of gradebookEntryLearningStandards.  
        /// </summary>
        public List<GradebookEntryLearningStandard> learningStandards { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

