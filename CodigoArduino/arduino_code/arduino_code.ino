
int led = 12;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(led, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:

    char order = Serial.read();
    
    if(order == '1'){
      digitalWrite(led, HIGH);
    }

     if(order == '0'){
      digitalWrite(led, LOW);
    }
    


}
