using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CelestialOrreryApp.Models
{
    public class CelestialObject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } // MongoDB primary key

        [Required]
        [StringLength(100)]
        public string Object { get; set; }

        public double EpochTdb { get; set; }
        public double TpTdb { get; set; }
        public double Eccentricity { get; set; }
        public double InclinationDeg { get; set; }
        public double ArgumentOfPeriapsisDeg { get; set; }
        public double NodeDeg { get; set; }
        public double PerihelionDistAU1 { get; set; }
        public double PerihelionDistAU2 { get; set; }
        public double OrbitalPeriodYr { get; set; }
        public double MinimumOrbitIntersectionDistAU { get; set; }
        public double NonGravitationalParameterA1 { get; set; }
        public double NonGravitationalParameterA2 { get; set; }
        public double NonGravitationalParameterA3 { get; set; }
        public double TimeOfPerihelionPassage { get; set; }

        [Required]
        [StringLength(50)]
        public string Reference { get; set; }

        [Required]
        [StringLength(100)]
        public string ObjectName { get; set; }
    }
}
