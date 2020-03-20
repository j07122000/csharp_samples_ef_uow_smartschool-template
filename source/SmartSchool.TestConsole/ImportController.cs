﻿using System;
using System.Collections.Generic;
using System.Linq;
using SmartSchool.Core.Entities;
using Utils;

namespace SmartSchool.TestConsole
{
    public class ImportController
    {
        const string Filename = "measurements.csv";

        /// <summary>
        /// Liefert die Messwerte mit den dazugehörigen Sensoren
        /// </summary>
        public static IEnumerable<Measurement> ReadFromCsv()
        {
            // throw new NotImplementedException();

            string[][] matrix = MyFile.ReadStringMatrixFromCsv(Filename, true);
            var sensors = matrix
                .GroupBy(line => line[2])
                .Select(s => new Sensor
                {
                    Location = s.Key.Split('_')[0],
                    Name = s.Key.Split('_')[1]

                })
                .ToArray();
            var measurements = matrix
                .Select(line => new Measurement
                {
                    Time = DateTime.Parse($"{line[0]} {line[1]}"),
                    Value = Double.Parse(line[3]),
                    Sensor = sensors.Single(s => line[2] == s.Location + '_' + s.Name)
                })
                .ToArray();
            return measurements;

        }

    }
}
