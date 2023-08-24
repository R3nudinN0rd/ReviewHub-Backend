using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.Entities
{
    public class LogAction
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Action code is required!")]
        public int ActionCode { get; set; }
        [Required(ErrorMessage = "Action message!")]
        public string ActionMessage { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
