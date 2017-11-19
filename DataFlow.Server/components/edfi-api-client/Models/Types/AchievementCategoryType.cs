using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Types 
{
    public class AchievementCategoryType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public int? achievementCategoryTypeId { get; set; }

        /// <summary>
        /// Code for achievement category type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// A shortened description for the achievement category type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// The description of the achievement category type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

