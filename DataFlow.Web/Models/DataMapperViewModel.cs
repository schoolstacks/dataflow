using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace DataFlow.Web.Models
{
    public class DataMapperViewModel
    {
        public string MapName { get; set; }
        public List<SelectListItem> Entities { get; set; }
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