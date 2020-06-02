using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngInt2.Models
{
    public class SensorTemperaturaUmidade
    {
        public int Id { get; set; }
        public string Temperatura { get; set; }
        public string Umidade { get; set; }

        public SensorTemperaturaUmidade()
        {
        }
    }
}
