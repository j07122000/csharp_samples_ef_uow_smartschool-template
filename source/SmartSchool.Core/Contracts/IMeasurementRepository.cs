using SmartSchool.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.Core.Contracts
{
    public interface IMeasurementRepository
    {
        void AddRange(Measurement[] measurements);
        Measurement[] GetLast3GreatestMeasurements(string name, string location);
        double GetAverageOfValidCo2(string location);
        long CountMeasurementsSensor(string name, string location);

    }
}
