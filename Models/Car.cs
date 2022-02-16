using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public int YearOfProduction { get; set; }
        public string PlateNumber { get; set; }
        public int VIN { get; set; }
        public int ClientId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Client Client { get; set; }
        public List<Appointment> Appointment { get; set; }
    }
}
