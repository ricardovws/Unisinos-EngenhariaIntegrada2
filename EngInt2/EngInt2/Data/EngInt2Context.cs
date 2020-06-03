using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EngInt2.Models;

namespace EngInt2.Models
{
    public class EngInt2Context : DbContext
    {
        public EngInt2Context (DbContextOptions<EngInt2Context> options)
            : base(options)
        {
        }

        public DbSet<SensorTemperaturaUmidade> SensorTemperaturaUmidade { get; set; }

        public DbSet<Comandos> Comandos { get; set; }

        public DbSet<EngInt2.Models.Configuracoes> Configuracoes { get; set; }
    }
}
