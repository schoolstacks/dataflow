using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataFlow.Web.Models
{
    public class DataMapperViewModel
    {
        [Display(Name = "Map Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a map name.")]
        public string MapName { get; set; }
        public List<SelectListItem> Entities { get; set; }
        [Display(Name = "Map to Entity")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an entity to map to.")]
        public string MapToEntity { get; set; }
        public List<string> Fields { get; set; }
        public string JsonMap { get; set; }

        public class Enums
        {
            public enum Sources
            {
                [Description("column")]
                Column,
                [Description("lookup_table")]
                LookupTable,
                [Description("static")]
                Static
            }

            public enum DataTypes
            {
                [Description("boolean")]
                Boolean,
                [Description("date")]
                Date,
                [Description("date-time")]
                DateTime,
                [Description("integer")]
                Integer,
                [Description("string")]
                String
            }
        }
    }
}