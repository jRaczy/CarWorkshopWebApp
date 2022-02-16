using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Cost { get; set; }
        public bool Paid { get; set; }
        public string Parts { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int CarId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Car Car { get; set; }
    }
}
