using System.ComponentModel.DataAnnotations.Schema;
using DataFlow.Models;

namespace DataFlow.Web.Models
{
    public class AgentViewModel : Agent
    {
        public AgentViewModel()
        {
            FormResult = new FormResult();
        }

        [NotMapped]
        public FormResult FormResult { get; set; }
    }
}