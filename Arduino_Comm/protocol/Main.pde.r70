#include "p_header.h"
#include <string.h>

// TODO: pass all return values to msg struct
// use the tx struct in msg protocl to do all serial prints EXCEPT the trace statements for debugs
// msg struct is a global var... 

void setup()
{
  Serial.begin(BAUD_RATE);        // Sets the baud rate
  pinMode(PUMP_PIN1, OUTPUT);    // Sets the pin mode for motor
  pinMode(PUMP_PIN2, OUTPUT);
  pinMode(PUMP_PIN3, OUTPUT);
  pinMode(BREATH_PIN, INPUT);     // Sets the pin mode for gas
  pinMode(FORCESENSOR_PIN, INPUT);     // Sets the pin mode for force sensor
  pinMode(TEST_LED, OUTPUT);
}

/*************************************************************************************************
 * wait for serial commands
 * The switch statement is set up as follows
 * the cases check the operation_device defined in p_header
 * inside each case, you set you compare the function name stored in msg.rx_data.func_name with 
 * predefined fucntion names in serial_action_name
 * then once that is found map that to the functon call as defined in its respective pde file
 **************************************************************************************************/
void loop() 
{   
  if (!ReadSerial())
  { 
    switch(msg.device)
    {
      case BREATH:
        if (!strcmp(serial_action_name[TESTBREATH], msg.rx_data.func_name))
          TestBreath(atoi(get_param(0)));
        else if (!strcmp(serial_action_name[GETBREATH], msg.rx_data.func_name))
        {
          // gets the result from breath analyser, Serial.print rets data back to C#
          msg.tx_data.i_output = GetBreath();
          Serial.print(msg.tx_data.i_output);
          TRACE(Serial.println("\nBREATH_RESULT:"); Serial.print(msg.tx_data.i_output);)
        }
        else {Serial.print(INVALID_RPC);}break;
      
      case PUMP:
        if (!strcmp(serial_action_name[SET_MOTOR], msg.rx_data.func_name))
        {
          // pump number x, on or off, delay, file op
          msg.tx_data.i_output = setMotor(atoi(get_param(0)), atoi(get_param(1)), atoi(get_param(2)));
          Serial.print(msg.tx_data.i_output);
          TRACE(Serial.println("\nret_val:");Serial.print(msg.tx_data.i_output);)
        }
        else {Serial.print(INVALID_RPC); }break;
     
     case FORCESENSOR:
        if (!strcmp(serial_action_name[GETFORCESENSOR], msg.rx_data.func_name))
        {
          // get reading from force sensor , serial.print reading back to c#
          msg.tx_data.i_output = GetForceSensor();
          Serial.print(msg.tx_data.i_output);
          TRACE(Serial.println("\nforce_detected_val:");Serial.print(msg.tx_data.i_output);)
        }
        else if (!strcmp(serial_action_name[TESTFORCESENSOR], msg.rx_data.func_name))
        {
          TestForceSensor();
        }
        else {Serial.print(INVALID_RPC); }break;
     
     case _LED:
       if (!strcmp(serial_action_name[TESTLED], msg.rx_data.func_name))
       {
         testled(atoi(get_param(0)), atoi(get_param(1)));
       }
       else {Serial.print(INVALID_RPC); }break;
     
     default:
       Serial.print(INVALID_DEVICE);
    }
  }
};
