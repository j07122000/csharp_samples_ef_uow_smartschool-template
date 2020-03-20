using SmartSchool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.Core.Contracts
{
    public interface ISensorRepository
    {
        IEnumerable<Sensor> GetSensorsAverage();
    }
}
