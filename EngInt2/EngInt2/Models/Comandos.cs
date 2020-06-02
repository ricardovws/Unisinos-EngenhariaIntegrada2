using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngInt2.Models
{
    public class Comandos
    {
        public int Id { get; set; }
        public string NomeComponente { get; set; }
        public int Ligado { get; set; }
        public int Desligado { get; set; }
        public int Status { get; set; }
        public StatusEnum Status_Enum { get; set; }
    }
}
