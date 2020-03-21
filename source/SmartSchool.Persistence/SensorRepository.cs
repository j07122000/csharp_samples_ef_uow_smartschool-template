using Microsoft.EntityFrameworkCore;
using SmartSchool.Core.Contracts;
using SmartSchool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Persistence
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SensorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddRange(Sensor[] sensors)
        {
            _dbContext.Sensors.AddRange(sensors);
        }

        public Sensor[] GetAllAsync()
        {
            return  _dbContext.Sensors
                .OrderBy(sensor => sensor.Name)
                .ToArray();
        }


        public async  Task<(Sensor Sensor, Double Average)[]> GetSensorsAverage()
        {
            var groupedMeasurements = await _dbContext.Measurements
                          .GroupBy(m => m.SensorId)
                          .Select(group => new
                          {
                              SensorId = group.Key,
                              Average = group.Average(m => m.Value)
                          })
                          .ToArrayAsync();
            var sensors = await _dbContext
                .Sensors
                .OrderBy(sensor => sensor.Location)
                .ThenBy(s => s.Name)
                .ToArrayAsync();
            return sensors
                .Select(s =>
                    (
                        s,
                        groupedMeasurements.Any(gm => gm.SensorId == s.Id) ? groupedMeasurements.Single(gm => gm.SensorId == s.Id).Average : -9999)
                )
                .ToArray();
        }
        

    }
}