
#include "p_header.h"
#include "Msg_Protocol.h"

#define FORCESENSOR_PIN A1
#define FORCESENSOR_THRESHOLD 5
#define FORCESENSOR_TIMEOUT 5000 // 5000 milisec
#define CUP_PRESENT 1
#define CUP_NOT_PRESENT 0

void setup()
{
  Serial.begin(BAUD_RATE);        // Sets the baud rate
  pinMode(FORCESENSOR_PIN, INPUT);     // Sets the pin mode for gas
}

int sensorValue = 0;  // variable to store the value coming from the sensor
int timeout =0;

int GetForceSensor (int rw) {
    if (rw == WRITE)
     return BAD_BREATH_OP;
    
    while (timeout < FORCESENSOR_TIMEOUT) {
        // read the value from the sensor:
      sensorValue = 1023 - analogRead(FORCESENSOR_PIN);  
      Serial.print("Reading: ");  
      Serial.println(sensorValue);
      if (sensorValue > FORCESENSOR_THRESHOLD) {
        Serial.println("Cup present ");  
        return CUP_PRESENT;
      }
      delay(100);    
      timeout +=100;
    } 
    Serial.println("Cup not present ");  
   return CUP_NOT_PRESENT;
}

void TestForceSensor() {
  GetForceSensor(READ);
  delay(5000);
}

