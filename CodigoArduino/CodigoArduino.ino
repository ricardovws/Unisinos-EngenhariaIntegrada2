#include <idDHT11.h>

int idDHT11pin = 2;       //Porta Digital do Arduino onde o Sinal do Sensor DHT esta conectado
int idDHT11intNumber = 0; //Número da interrupção

void dht11_wrapper();     // Declaração da funcão de controle da interrupção.
void loopDHT();           // Atualiza a leitura do sensor

idDHT11 DHT11(idDHT11pin, idDHT11intNumber, dht11_wrapper);   //Instanciação do Objeto de Controle do Sensor

//***Sobre os componentes de acionamento***//
int comp1 = 12; // Led branco - Sistema de exaustão
int comp2 = 11; //LED amarelo - Sistema de Irrigação
int comp3 = 10; //LED vermelho - Sistema de iluminação
int comp4 = 9; //Ventoinha - Sistema de ventilação

//***Sobre o sensor de umidade do solo (sensor HL-69)***//
int umidadeSolo = 0;
int analogPin = A2;

void setup() {

  Serial.begin(9600);
  pinMode(comp1, OUTPUT);
  pinMode(comp2, OUTPUT);
  pinMode(comp3, OUTPUT);
  pinMode(comp4, OUTPUT);
}

//Variaveis que irao conter os valores lidos no Sensor de temperatura e umidade do ar (DHT11)
float temperaturaC;
float temperaturaF;
float temperaturaK;
float umidade;
float dewPoint;
float dewPointSlow;

void loop() {

  loopDHT(); //loop dedicado para o sensor DHT, por questões de processamento.

  //Sensor de umidade do solo:

  // Lê pino do sensor de umidade do solo
  umidadeSolo = analogRead(analogPin); 
  
  // Converte variação do sensor de 0 a 1023, para 0 a 100.
  umidadeSolo = map(umidadeSolo, 1023, 0, 0, 100); 
  
  delay: (10000);

  //(Temperatura, Umidade e Umidade do solo)
  Serial.println(String(temperaturaC) + "," + String(umidade) + "," + String(umidadeSolo));

  //Serial.println("Temperatura: " + String(temperaturaC) + ", Umidade relativa do ar: " + String(umidade) + ", Umidade do solo: " + String(umidadeSolo));

  char order = Serial.read();

  //Led branco - Sistema de exaustão//
  if (order == '1') {
    digitalWrite(comp1, HIGH);
  }

  if (order == '2') {
    digitalWrite(comp1, LOW);
  }

  //LED amarelo - Sistema de Irrigação//
  if (order == '3') {
    digitalWrite(comp2, HIGH);
  }

  if (order == '4') {
    digitalWrite(comp2, LOW);
  }

  //LED vermelho - Sistema de iluminação//
  if (order == '5') {
    digitalWrite(comp3, HIGH);
  }

  if (order == '6') {
    digitalWrite(comp3, LOW);
  }

  //Ventoinha - Sistema de ventilação//
  if (order == '7') {
    digitalWrite(comp4, HIGH);
  }

  if (order == '8') {
    digitalWrite(comp4, LOW);
  }

}
void dht11_wrapper() {
  DHT11.isrCallback();
}

void loopDHT() {
#define tempoLeitura 1000
  static unsigned long delayLeitura = millis() + tempoLeitura + 1;
  static bool request = false;

  if ((millis() - delayLeitura) > tempoLeitura) {
    if (!request) {
      DHT11.acquire();
      request = true;
    }
  }

  if (request && !DHT11.acquiring()) {
    request = false;

    int result = DHT11.getStatus();

    switch (result)
    {
      case IDDHTLIB_OK:
        //Serial.println("Leitura OK");
        break;
      case IDDHTLIB_ERROR_CHECKSUM:
        //Serial.println("Erro\n\r\tErro Checksum");
        break;
      case IDDHTLIB_ERROR_ISR_TIMEOUT:
        //Serial.println("Erro\n\r\tISR Time out");
        break;
      case IDDHTLIB_ERROR_RESPONSE_TIMEOUT:
        //Serial.println("Erro\n\r\tResponse time out");
        break;
      case IDDHTLIB_ERROR_DATA_TIMEOUT:
        //Serial.println("Erro\n\r\tData time out erro");
        break;
      case IDDHTLIB_ERROR_ACQUIRING:
        //Serial.println("Erro\n\r\tAcquiring");
        break;
      case IDDHTLIB_ERROR_DELTA:
        //Serial.println("Erro\n\r\tDelta time to small");
        break;
      case IDDHTLIB_ERROR_NOTSTARTED:
        //Serial.println("Erro\n\r\tNao iniciado");
        break;
      default:
        //Serial.println("Erro Desconhecido");
        break;
    }

    float valor = DHT11.getCelsius();

    if (!isnan(valor)) {
      temperaturaC = valor;
    }

    valor = DHT11.getHumidity();
    if (!isnan(valor)) {
      umidade = valor;
    }

    valor = DHT11.getFahrenheit();
    if (!isnan(valor)) {
      temperaturaF = valor;
    }

    valor = DHT11.getKelvin();
    if (!isnan(valor)) {
      temperaturaK = valor;
    }

    valor = DHT11.getDewPoint();
    if (!isnan(valor)) {
      dewPoint = valor;
    }

    valor = DHT11.getDewPointSlow();
    if (!isnan(valor)) {
      dewPointSlow = valor;
    }

    delayLeitura = millis();
  }
}
