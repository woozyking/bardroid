using System;
using System.Collections.Generic;
using System.Text;

namespace BarTenderController
{
    public class ProtocolDef
    {
        public const char SEPARATOR = '=';
        public const char PARAM_SEPARATOR = ',';

        // Error codes
        public const string SUCCESS =  "\x0";
        public const string GENERIC_ERROR = "\x1";
        public const string MSG_NULL_ERROR = "\x2";
        public const string OUT_OF_BOUND_ERROR = "\x3";
        public const string SERIALPORT_NOT_OPENED_ERROR = "\x4";
        public const string SERIALPORT_READ_ERROR = "\x5";

        public const string ON = "1";
        public const string OFF = "0";

        public const string READ = "1";
        public const string WRITE = "0";

        public const string PUMP_DEVICE = "0";
        public const string BREATH_DEVICE = "1";
        public const string FORCESENSOR_DEVICE = "2";
        public const string CARDREADER_DEVICE = "3"; 
 
        public const string TEST_DEVICE = "9"; 


        public const string SET_MOTOR = "SetMotor";
        public const string GET_MOTOR = "GetMotor";
        public const string GET_BREATH = "GetBreath";
        public const string GET_CARDREADER = "GetCardReader";
        public const string GET_FORCESENSOR = "GetForceSensor";

        public const string TEST_LED = "testled";

        public const int PUMP_ON_INTERVAL = 1500;
        public const int PUMP_NUM_1 = 1;
        public const int PUMP_NUM_2 = 2;
        public const int PUMP_NUM_3 = 3;


        public const string CUP_PRESENCE = "0";
        public const string CUP_NOT_PRESENCE = "1";


    }
}
