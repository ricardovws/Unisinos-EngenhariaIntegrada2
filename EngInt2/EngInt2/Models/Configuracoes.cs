using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngInt2.Models
{
    public class Configuracoes
    {
        public int Id { get; set; }
        public int temperaturaIniciar { get; set; }
        public int umidadeIniciar { get; set; }

        public DateTime horarioAgora { get; set; }
        public DateTime horarioParaLigar { get; set; }
        public DateTime horarioParaDesligar { get; set; }
    }
}
