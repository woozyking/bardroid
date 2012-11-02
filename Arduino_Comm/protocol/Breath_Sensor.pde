#include <stdlib.h>
#include <string.h>
#include "p_header.h"

// starts breath analyser
// waits maximum of 7 seconds for a threshold change in sensor value
// returns either a pass, fail or try_again if it was inconclusive
int GetBreath()
{   
  int initBreathValue = 0;
  int retBreathValue = 0;
  int timeout = 0;
  
  // get current state of breathg analyser
  initBreathValue = analogRead(BREATH_PIN);
  
  // retBreath > Threshold > 0 when there is alcohol
  // retBreath < 0 when there is no alcohol
  while (retBreathValue < BREATH_THRESHOLD)
  {
    // sample every 100 ms
    retBreathValue = analogRead(BREATH_PIN) - initBreathValue;
    delay(100); timeout++;
    
    // (10 samples / second) * 7 seconds = 70
    if (timeout == 70)
      break; 
  }
  
  // return data to the user
  if (retBreathValue > BREATH_THRESHOLD)
    return FAIL;
  else if (retBreathValue < BREATH_THRESHOLD)
    return PASS;
  else
    return TRY_AGAIN;
};

// Kinda like a unit test to test GetBreath()
// Use this to get a stream of samples from the breathalyzer
int TestBreath(int runlen)
{
  for (int i = 0; i < runlen; i++)
  {
    int value = analogRead(BREATH_PIN);
    Serial.print("Alcohol:");
    Serial.println(value);
    delay(100);
  }
  Serial.println("Done Test");
};

