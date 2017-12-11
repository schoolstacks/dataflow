using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Models
{
    public partial class ApiConfigurationValues : DataFlow.Models.ApiConfigurationValues
    {
        public ApiConfigurationValues()
        {
            FormResult = new FormResult();
        }

        [NotMapped]
        public FormResult FormResult { get; set; }
    }
}