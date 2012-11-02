#include "p_header.h"
#include "Msg_Protocol.h"

int testled(int timeout, int forcedRetVal) 
{
   Serial.print("The test led is on pin: ");
   Serial.println(TEST_LED);
   delay(timeout);
   digitalWrite(TEST_LED, HIGH);
   Serial.print("Expected return value: ");
   Serial.println(forcedRetVal);
   delay(5000);
   digitalWrite(TEST_LED, LOW);

}

