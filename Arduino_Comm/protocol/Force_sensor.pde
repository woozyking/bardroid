
#include "p_header.h"
#include "Msg_Protocol.h"


int sensorValue = 0;  // variable to store the value coming from the sensor
int timeout =0;

int GetForceSensor () {
    timeout =0;
    while (timeout < FORCESENSOR_TIMEOUT) {
        // read the value from the sensor:
      sensorValue = 1023 - analogRead(FORCESENSOR_PIN);  
      if (sensorValue > FORCESENSOR_THRESHOLD) {
         return CUP_PRESENT;
      }
      delay(100);    
      timeout +=100;
    } 
   return CUP_NOT_PRESENT;
}

void TestForceSensor() {
    timeout =0;
    while (timeout < FORCESENSOR_TIMEOUT) {
        // read the value from the sensor:
        sensorValue = 1023 - analogRead(FORCESENSOR_PIN);  
        Serial.print("Reading: ");  
        Serial.println(sensorValue);
      if (sensorValue > FORCESENSOR_THRESHOLD) {
         Serial.println("Cup present ");          
      } else Serial.println("Cup not present ");  
      delay(100);    
      timeout +=100;
    } 
   Serial.println("Done");  
   
}

