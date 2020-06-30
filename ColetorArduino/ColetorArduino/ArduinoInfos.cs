using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ColetorArduino
{
    class ArduinoInfos
    {
        readonly Timer _timer;
        private readonly int _baudRate = 9600;
        private readonly string _portName = "COM3";


        public ArduinoInfos()
        {
            _timer = new Timer(5000) { AutoReset = true };

            _timer.Elapsed += (sender, eventArgs) =>

            Console.WriteLine("São {0} e este serviço está funcionando!", DateTime.Now);

            _timer.Elapsed += (sender, eventArgs) =>

            DadosDoArduino();
        }

        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }

        MySqlConnection connection = null;
        string connectionString = "server=localhost;uid=root;pwd=1234567;database=engint2";

        int id = 1;

        public void DadosDoArduino()
        {
            using (var serialPort = new SerialPort(_portName, _baudRate))
            {

                serialPort.Open();

                while (true)
                {
                    //Aqui o serviço pega a informação vinda da porta serial

                    string info = serialPort.ReadLine();


                    //Depois a informação é tratada e segue em frente
                    string[] dataToSplit = info.Split(',');

                    string temp = null;
                    string um = null;
                    string umS = null;

                    try
                    {
                        temp = dataToSplit[0];
                        um = dataToSplit[1];
                        umS = dataToSplit[2];
                    }

                    catch (IndexOutOfRangeException _e)
                    {
                        Console.WriteLine("Aiaiaiai! - " + _e.Message);
                        ;
                    }


                    //Aqui as informações oriundas da portal serial são salvas no banco.
                    SalvaNoBanco(id, temp, um, umS, connection, connectionString);

                    //Atualiza Id
                    id++;

                    //Pega a informação do banco e escreve na porta serial:
                    OrdenaAoArduino(connection, connectionString, serialPort);


                    //Gera um .txt só para ver se está funcionando sem olhar o banco
                    string[] _info_ = new string[] { "Temperatura, umidade relativa do ar e umidade do solo, são, respectivamente: " + info
                        + ", e você pode visualizar todas as outras informações no banco de dados." };
                    string nomeDoArquivo = "arduinoInfos";
                    string extensaoDoArquivo = "txt";
                    string enderecoDoArquivo = @"C:\Users\Ricardo\OneDrive\Documentos\Engenharia_Integrada_2\EngInt2\";
                    File.AppendAllLines(enderecoDoArquivo + nomeDoArquivo + "." + extensaoDoArquivo, _info_);
                    //************************************//

                }



            }
        }

        private void OrdenaAoArduino(MySqlConnection connection, string connectionString, SerialPort serialPort)
        {
            try
            {
    
                string query = "SELECT * FROM comandos";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    DBConnectionHelper(); ////
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        int status_ = (int)reader["Status"];
                        int status_enum = (int)reader["Status_Enum"];
                        string Status_To_Print = null;

                        if (status_enum == 0)
                        {
                            Status_To_Print = "Desligado";
                        }
                        else
                        {
                            Status_To_Print = "Ligado";
                        }

                        Console.WriteLine("Id: " + id + " está " + Status_To_Print);

                        serialPort.Write(status_.ToString());
                    }

                }
                connection.Close();//
            }
            catch (Exception e)
            {
                Console.WriteLine("Vish! Temos um erro aqui! - " + e.Message);
            }
        }


        private void SalvaNoBanco(int id, string temperatura, string umidade, string umidadeSolo, MySqlConnection connection, string connectionString)
        {
            InformacaoDiretoDoArduino info = new InformacaoDiretoDoArduino();
            info.Id = id;
            info.Temperatura = temperatura;
            info.Umidade = umidade;
            info.UmidadeSolo = umidadeSolo;
            
            try
            {

                string query = "INSERT INTO sensortemperaturaumidade (Id, Temperatura, Umidade, UmidadeSolo) VALUES (@Id, @Temperatura, @Umidade, @UmidadeSolo)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    DBConnectionHelper(); ////

                    command.Parameters.AddWithValue("@Id", info.Id);
                    command.Parameters.AddWithValue("@Temperatura", info.Temperatura);
                    command.Parameters.AddWithValue("@Umidade", info.Umidade);
                    command.Parameters.AddWithValue("@UmidadeSolo", info.UmidadeSolo);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Foi salvo no banco de dados!");

                }
                connection.Close();//
            }

            catch (Exception e)
            {
                Console.WriteLine("Ouups! - " + e.Message);

                //Se já há o id no banco, aqui o id é atualizado para o último disponível:
                AtualizarId();
            }

        }

        private void AtualizarId()
        {
            //DBConnectionHelper();

            string query = "SELECT MAX(Id) FROM sensortemperaturaumidade";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                DBConnectionHelper(); ////

                var novoId = (int)command.ExecuteScalar();

                id = novoId;

            }

        }

        private void DBConnectionHelper()
        {
            connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
        }
    }
}
