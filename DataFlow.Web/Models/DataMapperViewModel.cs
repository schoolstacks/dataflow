using System.Collections.Generic;
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
            Fields = new List<DataMapper>();
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
        public List<DataMapper> Fields { get; set; }
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
                fields.Add(f.DataMapperProperty.UniqueKey);

                f.SubDataMappers.ForEach(s =>
                {
                    fields.Add(s.DataMapperProperty.UniqueKey);

                    s.SubDataMappers.ForEach(t =>
                    {
                        fields.Add(t.DataMapperProperty.UniqueKey);
                    });
                });
            });

            return fields;
        }

        public bool IsSuccess { get; set; }
        public bool ShowInfoMessage { get; set; }
        public string InfoMessage { get; set; }
    }
}