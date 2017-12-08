using System;
using System.ComponentModel.DataAnnotations;

namespace DataFlow.Models
{
    public partial class BootstrapData
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an entity.")]
        public int EntityId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the JSON Data.")]
        public string Data { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter when this data should be processed.")]
        [Display(Name = "Processing Order")]
        public int ProcessingOrder { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Entity Entity { get; set; }
    }
}
