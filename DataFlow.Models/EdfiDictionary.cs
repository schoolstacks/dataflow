using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class EdfiDictionary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string GroupSet { get; set; }
        [Required, MaxLength(255)]
        public string OriginalValue { get; set; }
        [Required, MaxLength(255)]
        public string DisplayValue { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
