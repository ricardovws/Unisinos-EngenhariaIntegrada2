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
        public int temperaturaTerminar { get; set; }
        public int umidadeIniciar { get; set; }
        public int umidadeTerminar { get; set; }


        public bool statusReferencia { get; set; }
        public int tempoLigado { get; set; }
        public int tempoDesligado { get; set; }
        public DateTime horarioInicial { get; set; } //antes era horarioParaLigar
        public DateTime horarioFinal { get; set; } //horarioParaDesligar
    }
}
