using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ColetorArduino
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<ArduinoInfos>(s =>
                {
                    s.ConstructUsing(name => new ArduinoInfos());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("É um serviço que pega dados do Arduino e os salva em um banco de dados.");
                x.SetDisplayName("Coletor de dados do Arduino");
                x.SetServiceName("ColetorArduino");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
