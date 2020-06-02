//***About temperature&humidity sensor***//
#include <dht.h>
dht DHT;
#define DHT11_PIN 2
///////////////////////////////////////////

//***About LED's***//
int ledWhite = 12;
int ledYellow = 11;
int ledRed = 10;
int ledGreen = 9;

///////////////////////////////////////////

void setup(){
  Serial.begin(9600);

  pinMode(ledWhite, OUTPUT);
  pinMode(ledYellow, OUTPUT);
  pinMode(ledRed, OUTPUT);
  pinMode(ledGreen, OUTPUT);
}


void loop()
{
  //Sensor//
  int chk = DHT.read11(DHT11_PIN);
  //(Temperature, Humidity)
  Serial.println(String(DHT.temperature) + "," + String(DHT.humidity));
  delay(1000);

  //LED//

  char order = Serial.read();
 
    //White//
    if(order == '1'){
      digitalWrite(ledWhite, HIGH);
    }

     if(order == '2'){
      digitalWrite(ledWhite, LOW);
    }

    //Yellow//
    if(order == '3'){
      digitalWrite(ledYellow, HIGH);
    }

     if(order == '4'){
      digitalWrite(ledYellow, LOW);
    }

     //Red//
    if(order == '5'){
      digitalWrite(ledRed, HIGH);
    }

     if(order == '6'){
      digitalWrite(ledRed, LOW);
    }

      //Green//
    if(order == '7'){
      digitalWrite(ledGreen, HIGH);
    }

     if(order == '8'){
      digitalWrite(ledGreen, LOW);
    }

}
