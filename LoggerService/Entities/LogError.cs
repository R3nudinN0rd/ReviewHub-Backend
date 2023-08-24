using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.Entities
{
    public class LogError
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Error code is required!")]
        public int ErrorCode { get; set; }
        [Required(ErrorMessage = "Error message is required!")]
        public string ErrorMessage { get; set; }
        public DateTime LoggedDate { get; set; }
    }
}
