using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Models
{
    public class TypeOfRepair
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public int PhoneNumber { get; set; }
    }
}
