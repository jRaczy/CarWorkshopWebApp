using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CarModel { get; set; }
        public string PlateNumber { get; set; }
        public int Cost { get; set; }
        public bool Paid { get; set; }
    }
}
