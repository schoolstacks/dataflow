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
        public List<Field> Fields { get; set; }
        public string JsonMap { get; set; }

        public List<SelectListItem> SourceTables { get; set; }
        public List<SelectListItem> DataSources { get; set; }

        public class Field
        {
            public Field(string name, string dataType)
            {
                Name = name;
                DataType = dataType;
            }

            public string Name { get; set; }
            public string DataType { get; set; }
        }
    }
}