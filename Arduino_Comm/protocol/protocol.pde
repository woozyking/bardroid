#include "p_header.h"
#include <string.h>

//#define TRACE_ON // turn off trace when using with c#
/*****************************************************
 * Some Dev Notes: 
 * sample input=  "00SetMotor=param1,param2,...,paramN"
 * setmotor(int motor, int value)
 * at the end of serial input its a -1 for EOF
 *****************************************************/

/*****************************************************
 * General Note: This should be the only file that interfaces
 * with external apps. All values that are returned must be
 * INT, and returned via ret_val for clarity 
 ******************************************************/

void HELP()
{
  Serial.println("Protocol Stack for RX");
  Serial.println("(1 Byte) device identifier");
  Serial.println("(1 Byte) RW read [1] / write [0] to PIN");
  Serial.println("(X Bytes) func_name (read untill terminating char '=')");
  Serial.println("(Y Bytes) input value or param (comma seperated)");
  Serial.println("EXAMPLE: '0SetMotor=param1,param2,param3'");
  Serial.println("EXAMPLE: 0SetMotor=<motor num>,< 1 = on>,<duration in ms>,");
  Serial.println("EXAMPLE: 1GetBreath=");
  Serial.println("EXAMPLE: 1TestBreath=<Number of samples to take>");
  Serial.println("EXAMPLE: 2TestForceSensor=");
  Serial.println("EXAMPLE: 2GetForceSensor=");
  Serial.println("EXAMPLE: 9testled=<delay before on in ms>,<return value expected>");
}

// verify that the input put has an '=' sign as a delimeter for function name 
// also verifys that the device_identifier is correct
int verify_input(char *input)
{
  if (strlen(input) <= 0)
    return true;
  if (!strcmp(input, "help"))
    {
      HELP();
      return true;
    }
    
  char temp_char = input[0]; // arduinos.. quirkyness does not allow input[0] directly into atoi... without the use of &
  int device_identifier = atoi(&temp_char);
  
  if (device_identifier >=0 && device_identifier <= 9);
  else return INVALID_DEVICE;  
  
  for (int i = 1; i<strlen(input); i++) // starts from 1 to skip the first byte that was checked above
    if (input[i] == SEPARATOR)
      return SUCCESS;
};
                                  // Read Data from serial
int ReadSerial()                  // read incoming message sent from C#
{
  char  serial_buffer[BUF_LEN];    // used to parse out segements from serial data
  char  serial_data[BUF_LEN];      // used to store the data on the serial port
  char  temp_byte;
  int   i = 0;
  int   buff_index = 0;
  
  if (Serial.available() > 0)
  {
    while (Serial.available()>0 && i < BUF_LEN)                                  // need a delay cuz audrino so damn slow...
    {
      serial_data[i++] = Serial.read();
      delay(10);
    }
    serial_data[i] = '\0';
    //stateStatus = FREE;
    TRACE(Serial.println("\nserial_data:");Serial.print(serial_data);Serial.println("\nserial_data len:");Serial.println(strlen(serial_data));)
    int valid_flag = verify_input(serial_data); // check if the data has been input correctly
    TRACE(Serial.println("vlaid Flag: "); Serial.print(valid_flag);)  
    if (!valid_flag)
      stateStatus = FREE;  
  }
  else stateStatus = BUSY;                                                         // waiting for serial input
  
  while (strlen(serial_data) && stateStatus == FREE)
  {
    i = 0; // retset i to point at start of buffer
    temp_byte = serial_data[i++]; // put the device identifier in to protocol
    msg.device = atoi(&temp_byte);
    
    TRACE(Serial.println("\nMsg.device:");Serial.print((int)msg.device);)
    //TRACE(Serial.println("\nMsg.rx_data.RW:");Serial.print((int)msg.rx_data.RW);)
       
    while(i != strlen(serial_data))                                                   // next is for function name
    { 
      if (serial_data[i] != SEPARATOR)
        serial_buffer[buff_index++] = serial_data[i++];                               // store the string for function pointer
      else
      {
        serial_buffer[buff_index] = '\0';                                             // add terminating char to buffer
        msg.rx_data.func_name = (char*)calloc(strlen(serial_buffer)+1,sizeof(char));  // create a buffer the size of the input
        strncpy(msg.rx_data.func_name, serial_buffer,strlen(serial_buffer)+1);        // copy the buffer to our struct
        memset(serial_buffer,NULL,strlen(serial_buffer)+1);                           // clear the serial_buffer
        TRACE(Serial.println("\nmsg.rx_data.func_name:");Serial.print(msg.rx_data.func_name);)
        break;
      }
    }
    
    buff_index = 0;                                                                     // reset the buffer index
    while(i != strlen(serial_data)+1)
    {
      if (i++ != strlen(serial_data))
        serial_buffer[buff_index++] = serial_data[i];                                   // store the string for function pointer
      else
      {
        serial_buffer[buff_index] = '\0';                                               // add terminating char to buffer
        msg.rx_data.parameters = (char*)calloc(strlen(serial_buffer)+1, sizeof(char));  // create a buffer the size of the input
        strncpy(msg.rx_data.parameters, serial_buffer, strlen(serial_buffer)+1);        // copy the buffer to our struct
        memset(serial_buffer,NULL,strlen(serial_buffer)+1);
        buff_index = 0;
        TRACE(Serial.println("\nmsg.rx_data.parameters:");Serial.print(msg.rx_data.parameters);)
        break;
      }
    }
    memset(serial_data,NULL,strlen(serial_data)+1);
    return SUCCESS;
    break;                                                                             // break out of read loop we got what we want
  }
  return GENERIC_ERROR;
};


/******************************************************************
 * Function parses out the parameter from the param string that was 
 * feed in from the serial input. 
 * to use just call get_param(<param num>) -- retuns a CHAR! 
 * use atoi() if input is expected to be an INT. else all inputs
 * are assumed to be a char array!
 ******************************************************************/
char* get_param(int num)
{
  char buffer[BUF_LEN];
  int i,j=0;
  int current_param = 0;
  
  if (msg.device < 0)
    return (char*)MSG_NULL_ERROR;
  
  while(j<strlen(msg.rx_data.parameters))
  {
    while (msg.rx_data.parameters[j] != PARAM_SEPARATOR && msg.rx_data.parameters[j] != '\0')
    {
      buffer[i] = msg.rx_data.parameters[j]; i++; j++;
    }
    if (current_param == num)
    {
      buffer[i] = '\0'; 
      TRACE(Serial.println("\nParam_buffer is: ");Serial.print(buffer);)
      return buffer;
    }
    current_param++;j++; // to get past the comma its currently pointing to 
    i = 0;               // reset buffer ptr to start
  }
  return (char*)OUT_OF_BOUND_ERROR; 
};




