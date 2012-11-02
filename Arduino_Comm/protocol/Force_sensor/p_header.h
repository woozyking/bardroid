#include <stdlib.h>
#include <string.h>

#ifndef HEADER_FILE
#define HEADER_FILE
/****************************************************** 
Protocol Stack for RX
(1 Byte) device
(1 Byte) RW read / write to PIN
(X Bytes) func_name (read untill terminating char "=")
(Y Bytes) input value or param (comma seperated)
EXAMPLE: "00SetMotor=param1,param2"

Protocol Stack for TX
(X Bytes) Return device
(Y Bytes) Return Value (Success/err code/ret data)
EXAMPLE: "MOTORA=ON"
********************************************************/

#define DO(x) x
#define IGNORE(x)

//#define TRACE_ON

#ifdef TRACE_ON
#define TRACE DO
#else
#define TRACE IGNORE
#endif
// Error codes
#define SUCCESS            0x0
#define GENERIC_ERROR      0x1001
#define MSG_NULL_ERROR     0x1002
#define OUT_OF_BOUND_ERROR 0x1003
#define BAD_PUMP_OP        0x1004
#define INVALID_PUMP_NUM   0x1005
#define BAD_BREATH_OP      0x1006
#define INVALID_DEVICE     0x1007
// Devices to be controled
#define PUMP             0   
#define BREATH           1     
#define FORCESENSOR      2  
#define CARDREADER       3
// Pump defines
#define PUMP1            1
#define PUMP2            2
#define PUMP3            3
#define ALL_PUMPS        0
// File operations
#define READ             1
#define WRITE            0
// Device Operations
#define START_PUMP       1
#define STOP_PUMP        0
#define BREATH_THRESHOLD        50
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
                   
enum serial_action {
                    SET_MOTOR = 0, 
                    READ_MOTOR = 1,
                    GETBREATH, 
                    START_BREATHANALYSER, 
                    STOP_BREATHANALYSER,
                    TESTBREATH 
                   }; 
                   
const char *serial_action_name[] = {
                                    "SetMotor", 
                                    "GetMotor", 
                                    "GetBreath",
                                    "StartBreathrSensor", 
                                    "StopBreathrSensor",
                                    "TestBreath" 
                                   };
                                   
                                                          
//Arduino Pin Assignments
#define  BREATH_PIN      A0
int  MOTOR_PIN1      = 3;
int  MOTOR_PIN2      = 4;
int  MOTOR_PIN3      = 7;
int  stateStatus     = FREE;  //state of machine
int  breathValue     = 0;     //value from gas sensor
char incomingChar;

//sample input=  "00SetMotor=param1,param2,...,paramN"
//setmotor(int motor, int value)
#endif
