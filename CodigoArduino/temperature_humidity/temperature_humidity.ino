#include <dht.h>

dht DHT;

#define DHT11_PIN 2

void setup(){
  Serial.begin(9600);
}

void loop()
{
  int chk = DHT.read11(DHT11_PIN);

  //(Temperature, Humidity)
  Serial.println(String(DHT.temperature) + "," + String(DHT.humidity));
  
  delay(1000);
}
