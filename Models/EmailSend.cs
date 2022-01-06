using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Models
{
    public class EmailSend
    {
        [Key]
        public int Id { get; set; }
        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
