using SmartSchool.Core.Contracts;
using SmartSchool.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Persistence
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private ApplicationDbContext _dbContext;

        public MeasurementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  void AddRange(Measurement[] measurements)
        {
            _dbContext.Measurements.AddRange(measurements);
        }
        public Measurement[] GetLast3GreatestMeasurements(string name, string location)
        {
            return _dbContext.Measurements
                .Where(s => s.Sensor.Name == name && s.Sensor.Location == location)
                .OrderByDescending(s => s.Value)
                .ThenByDescending(t => t.Time)
                .Take(3)
                .ToArray();
        }
        public double GetAverageOfValidCo2(string location)
        {
            return _dbContext.Measurements
                .Where(l => l.Sensor.Location == location && l.Sensor.Name == "Co2" && l.Value > 300 && l.Value < 5000)
                .Average(a => a.Value);
                
                
        }
        public long CountMeasurementsSensor(string name, string location)
        {
            return _dbContext.Measurements
           .Where(s => s.Sensor.Name == name && s.Sensor.Location == location)
           .LongCount();
           
        }



    }
}