﻿using System.Collections.Generic;
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
        public string MapToEntity { get; set; }
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

        public bool IsSuccess { get; set; }
        public bool ShowInfoMessage { get; set; }
        public string InfoMessage { get; set; }

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