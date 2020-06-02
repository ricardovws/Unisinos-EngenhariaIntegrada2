using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngInt2.Models
{
    public class InformacoesViewModel
    {
        public int Id { get; set; }
        public string Temperatura { get; set; }
        public string Umidade { get; set; }
        public string UmidadeSolo { get; set; }

        public StatusEnum Status1 { get; set; }
        public StatusEnum Status2 { get; set; }
        public StatusEnum Status3 { get; set; }
        public StatusEnum Status4 { get; set; }
    }
}
