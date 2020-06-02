using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EngInt2.Models;

namespace EngInt2.Controllers
{
    public class HomeController : Controller
    {

        private readonly EngInt2Context _context;

        public HomeController(EngInt2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var info = MostrarDadosSensor();

            var component_1 = _context.Comandos.FirstOrDefault(x => x.Id == 1).Status_Enum;
            var component_2 = _context.Comandos.FirstOrDefault(x => x.Id == 2).Status_Enum;
            var component_3 = _context.Comandos.FirstOrDefault(x => x.Id == 3).Status_Enum;
            var component_4 = _context.Comandos.FirstOrDefault(x => x.Id == 4).Status_Enum;

            info.Status1 = component_1;
            info.Status2 = component_2;
            info.Status3 = component_3;
            info.Status4 = component_4;


            return View(info);
        }

        private InformacoesViewModel MostrarDadosSensor()
        {
            var info = _context.SensorTemperaturaUmidade.LastOrDefault();
            InformacoesViewModel viewModel = new InformacoesViewModel();

            try
            {
                viewModel.Id = info.Id;
                viewModel.Temperatura = info.Temperatura + " °C";
                viewModel.Umidade = info.Umidade + " %";
            }

            catch (NullReferenceException)
            {
                viewModel.Id = 0;
                viewModel.Temperatura = "Infelizmente, nenhuma informação foi encontrada no banco de dados.";
                viewModel.Umidade = "Infelizmente, nenhuma informação foi encontrada no banco de dados.";
            }

            return viewModel;
        }

        public object AtualizaDadosSensor()
        {
            var info = MostrarDadosSensor();

            return PartialView("_SensorInfo", info);
        }

        public string MandaComando(int id, string comando)
        {
            var componente = _context.Comandos.First(x => x.Id == id);
            if (comando == "Ligar")
            {
                componente.Status = componente.Ligado;
                componente.Status_Enum = Models.StatusEnum.Ligado;
            }
            else
            {
                componente.Status = componente.Desligado;
                componente.Status_Enum = Models.StatusEnum.Desligado;
            }

            _context.Comandos.Update(componente);
            _context.SaveChanges();

            return comando;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
