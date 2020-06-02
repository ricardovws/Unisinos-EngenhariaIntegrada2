using EngInt2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngInt2.Data
{
    public class SeedingService
    {
        private readonly EngInt2Context _context;

        public SeedingService(EngInt2Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (
                _context.Comandos.Any()
                ||
                _context.SensorTemperaturaUmidade.Any()
                )
            {
                return; //DB has been seeded.
            }


            Comandos com1 = new Comandos
            {
                Id = 1,
                NomeComponente = "LED Branco",
                Ligado = 1,
                Desligado = 2,
                Status = 2
            };

            Comandos com2 = new Comandos
            {
                Id = 2,
                NomeComponente = "LED Amarelo",
                Ligado = 3,
                Desligado = 4,
                Status = 4
            };

            Comandos com3 = new Comandos
            {
                Id = 3,
                NomeComponente = "LED Vermelho",
                Ligado = 5,
                Desligado = 6,
                Status = 6
            };

            Comandos com4 = new Comandos
            {
                Id = 4,
                NomeComponente = "LED Verde",
                Ligado = 7,
                Desligado = 8,
                Status = 8
            };

            _context.AddRange(com1, com2, com3, com4);
            _context.SaveChanges();

        }

    }
}
