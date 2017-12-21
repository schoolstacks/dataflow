using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class Lookup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a group set.")]
        [Display(Name = "Group Set")]
        [MaxLength(1024)]
        public string GroupSet { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a key.")]
        [MaxLength(1024)]
        public string Key { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a value for the key.")]
        [MaxLength(1024)]
        public string Value { get; set; }
    }
}
