using SmartSchool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.Core.Contracts
{
    public interface ISensorRepository
    {
        void AddRange(Sensor[] sensors);
        Sensor[] GetAllAsync();
       

        Task<(Sensor Sensor, Double Average)[]> GetSensorsAverage();
    }
}
