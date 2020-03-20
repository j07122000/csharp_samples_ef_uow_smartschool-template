using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Core.Entities
{
    /// <summary>
    /// Sensor mit Messwerten (Measurements)
    /// </summary>
    public class Sensor : EntityObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Unit { get; set; }
        public ICollection<Measurement> Measurements { get; set; }

        public override string ToString()
        {
            return $"{Location,20:c}|{Name,20:c}|          Average Value: {Math.Round(Measurements.Average(m => m.Value), 2),5}";
        }

    }
}
