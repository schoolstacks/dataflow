using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace DataFlow.Web.Models
{
    public class DataMapperViewModel
    {
        public DataMapperViewModel()
        {
            Entities = new List<SelectListItem>();
            Fields = new List<Field>();
            CsvColumnHeaders = new List<string>();
            SourceTables = new List<SelectListItem>();
            DataSources = new List<SelectListItem>();
        }

        [Display(Name = "Map Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a map name.")]
        public string MapName { get; set; }
        public List<SelectListItem> Entities { get; set; }
        [Display(Name = "Map to Entity")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an entity to map to.")]
        public int? MapToEntity { get; set; }
        public List<Field> Fields { get; set; }
        public List<string> CsvColumnHeaders { get; set; }
        public DataTable CsvPreviewDataTable { get; set; }

        public List<SelectListItem> SourceColumns
        {
            get
            {
                var souceColumns = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Select Source Column", Value = string.Empty}
                };
                souceColumns.AddRange(CsvColumnHeaders.Select(x => new SelectListItem() { Text = x, Value = x }));

                return souceColumns;
            }
        }
        [Display(Name = "Json Map")]
        public string JsonMap { get; set; }

        public List<SelectListItem> SourceTables { get; set; }
        public List<SelectListItem> DataSources { get; set; }

        public List<string> GetAllFieldNames()
        {
            var fields = new List<string>();
            
            Fields.ForEach(f =>
            {
                fields.Add(f.FormFieldName);
                fields.AddRange(f.SubFields.Select(x => x.FormFieldName));
                //fields.AddRange(f.SubFields.SelectMany(x => x.SubFields.Select(y => x.FormFieldName)));
                //if (f.SubFields.Any())
                //{
                //    fields.AddRange(f.SubFields.Select(x => x.Name));

                //    if (f.SubFields.Any(x => x.SubFields.Any()))
                //    {
                //        fields.AddRange(f.SubFields.SelectMany(x => x.SubFields.Select(y => y.Name)));
                //    }
                //}
            });

            return fields;
        }

        public bool IsSuccess { get; set; }
        public bool ShowInfoMessage { get; set; }
        public string InfoMessage { get; set; }

        public class Field
        {
            public Field(string name, string dataType, string childType, string parentType, string formFieldName)
            {
                Name = name;
                DataType = dataType;
                ChildType = childType;
                ParentType = parentType;
                FormFieldName = formFieldName;
                SubFields = new List<Field>();
            }

            public string Name { get; set; }
            public string DataType { get; set; }
            public string ChildType { get; set; }
            public string ParentType { get; set; }
            public string FormFieldName { get; set; }
            public List<Field> SubFields { get; set; }
        }
    }
}