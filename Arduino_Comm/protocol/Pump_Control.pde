#include <stdlib.h>
#include <string.h>
#include "p_header.h"

int setMotor(int pump, int operation, int time)
{
  TRACE(Serial.print("\nDelay:");Serial.println(time);)
  TRACE(Serial.print("\nmotor:");Serial.println(pump);)

  if (operation == START_PUMP)
   operation = HIGH;
  else if (operation == STOP_PUMP)
   operation = LOW; 
  
  // Choose Pump To Turn On
  if (PUMP1 == pump)
  {  
    digitalWrite(PUMP_PIN1, operation);
    delay(time);
    digitalWrite(PUMP_PIN1, LOW);
    return SUCCESS;
  }
  else if (PUMP2 == pump)
  {
    digitalWrite(PUMP_PIN2, operation);
    delay(time);
    digitalWrite(PUMP_PIN2, LOW);
    return SUCCESS;
  }
  else if (PUMP3 == pump)
  {
    digitalWrite(PUMP_PIN3, operation);
    delay(time);
    digitalWrite(PUMP_PIN3, LOW);
    return SUCCESS;
  }
  else if (ALL_PUMPS == pump)
  {
    //digitalWrite(PUMP_PIN1, HIGH);
    //digitalWrite(PUMP_PIN2, HIGH);
    digitalWrite(PUMP_PIN3, HIGH);
  }
  else
    return INVALID_PUMP_NUM;
  
  return SUCCESS;
};

