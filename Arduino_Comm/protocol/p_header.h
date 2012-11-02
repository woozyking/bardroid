#include <stdlib.h>
#include <string.h>
#include "Msg_Protocol.h"

#ifndef HEADER_FILE
#define HEADER_FILE
/****************************************************** 
Protocol Stack for RX
(1 Byte) device
(X Bytes) func_name (read untill terminating char "=")
(Y Bytes) input value or param (comma seperated)
EXAMPLE: "0SetMotor=param1,param2,param3"

Protocol Stack for TX
(X Bytes) int return value or string
(Y Bytes) Return Value (Success/err code/ret data)
// working towards getting all return values to be ints
********************************************************/

#define DO(x) x
#define IGNORE(x)

//#define TRACE_ON
//#define _UNO 

#ifdef TRACE_ON
#define TRACE DO
#else
#define TRACE IGNORE
#endif

// init the msg struct
struct MSG_PROTOCOL msg;

// Error codes
#define SUCCESS            0x0
#define GENERIC_ERROR      0x1001
#define MSG_NULL_ERROR     0x1002
#define OUT_OF_BOUND_ERROR 0x1003
#define BAD_PUMP_OP        0x1004
#define INVALID_PUMP_NUM   0x1005
#define BAD_BREATH_OP      0x1006
#define INVALID_DEVICE     0x1007
#define INVALID_OPERATION  0x1008
#define INVALID_RPC        0x1009

// Devices to be controled
#define PUMP             0   
#define BREATH           1     
#define FORCESENSOR      2  
#define CARDREADER       3
#define LEVELSENSOR      4
#define _LED             9

// Pump defines
#define PUMP1            1
#define PUMP2            2
#define PUMP3            3
#define ALL_PUMPS        0
#define START_PUMP       1
#define STOP_PUMP        0

// File operations
#define READ             1
#define WRITE            0

// Breath defines
#define BREATH_THRESHOLD 500
#define PASS             0
#define FAIL             1
#define TRY_AGAIN       -1

// Force Sensor defines
#define FORCESENSOR_THRESHOLD 20
#define FORCESENSOR_TIMEOUT 5000 // 5000 milisec
#define CUP_PRESENT 0
#define CUP_NOT_PRESENT 1

// level Sensor defines
#define LEVELSENSORSENSOR_THRESHOLD 100
#define LEVELSENSORSENSOR_TIMEOUT 5000 // 5000 milisec
#define LEVELSENSOR1            1
#define LEVELSENSOR2            2
#define LEVELSENSOR3            3
#define PASS 0
#define FAIL 1

// Consts
#define EOF              -1
#define READ_BREATH      1
#define SEPARATOR        '='
#define PARAM_SEPARATOR  ','

// Arduino Setup Parameters
#define BAUD_RATE        9600
#define BUF_LEN          128

enum serial_status {
                    FREE = 0, 
                    BUSY = 1
                   }; 
                   
// add function identifier here
enum serial_action {
                    SET_MOTOR = 0, 
                    GETBREATH, 
                    TESTBREATH,
                    GETFORCESENSOR,
                    TESTFORCESENSOR,
                    GETLEVELSENSOR,
                    TESTLEVELSENSOR,
                    TESTLED 
                   }; 
                   
// Add function names here
const char *serial_action_name[] = {
                                    "SetMotor", 
                                    "GetBreath",
                                    "TestBreath",
                                    "GetLevelSensor",
                                    "TestLevelSensor",
                                    "GetForceSensor",
                                    "TestForceSensor",                                  
                                    "testled"
                                   };
                                   
                                                          
//Arduino Pin Assignments
#ifdef _UNO
  #define  BREATH_PIN       A0 // use this for UNO
  #define  FORCESENSOR_PIN  A1 // use this for UNO
#else
  int FORCESENSOR_PIN = 1;
  int BREATH_PIN      = 0; // use this for demulative
#endif

int LEVELSENSOR_PIN1 = 2;
int LEVELSENSOR_PIN2 = 5;
int LEVELSENSOR_PIN3 = 6;
int  PUMP_PIN1       = 3; // physical pins the pumps are connected to
int  PUMP_PIN2       = 4;
int  PUMP_PIN3       = 7;
int  TEST_LED        = 13;
int  stateStatus     = FREE;  //state of machine

//sample input=  "0SetMotor=param1,param2,param3"
//setmotor(int motor, int value, int duration)
#endif
