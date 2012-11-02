#include "p_header.h"
#include "Msg_Protocol.h"


int sensorPin = 0;
int request = 0;


int GetLevelSensor(int selection, int op ) {
  sensorValue = 0;  // variable to store the value coming from the sensor
  switch (selection) {
        case LEVELSENSOR1:
           sensorPin = LEVELSENSOR_PIN1;
           break;
        case LEVELSENSOR2:
           sensorPin = LEVELSENSOR_PIN2;
           break;
        case LEVELSENSOR3:
           sensorPin = LEVELSENSOR_PIN3;
           break;
        default:
          return INVALID_DEVICE;
    }  
    
    timeout = 0;
    // read the value from the sensor:
    sensorValue = 1023 - analogRead(sensorPin);  
    request = op * 1023 / 20000;
    if (sensorValue > request)
      return PASS; 
    else
      return FAIL;
      
}

void TestLevelSensor(int selection) {
  sensorValue = 0;  // variable to store the value coming from the sensor
    switch (selection) {
        case LEVELSENSOR1:
           sensorPin = LEVELSENSOR_PIN1;
           break;
        case LEVELSENSOR2:
           sensorPin = LEVELSENSOR_PIN2;
           break;
        case LEVELSENSOR3:
           sensorPin = LEVELSENSOR_PIN3;
           break;
        default:             
            Serial.println("Invalid Sensor Selection");
            
    }  
    timeout =0;
    while (timeout < LEVELSENSORSENSOR_TIMEOUT) {
        // read the value from the sensor:
        sensorValue = 1023 - analogRead(sensorPin);  
        Serial.print("Reading: ");  
        Serial.println(sensorValue);
      if (sensorValue > LEVELSENSORSENSOR_THRESHOLD) {
         Serial.println("Cup present ");          
      } else Serial.println("Cup not present ");  
      delay(100);    
      timeout +=100;
    } 
   Serial.println("Done");  
   
}
