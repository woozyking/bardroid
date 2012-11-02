using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
namespace BarTenderController
{
    public sealed class BarTenderController
    {
        private const bool DEBUG = false;

        private SerialPort serialPort;
        static BarTenderController controller;
        static readonly object padlock = new object();
        


        private BarTenderController()
        {
            this.serialPort = new SerialPort();            
            this.serialPort.BaudRate = 9600;
            this.serialPort.PortName = "COM6";
            if (!DEBUG && !this.serialPort.IsOpen)
                this.serialPort.Open();  
            //OpenBoard(5);
        }

        private void OpenBoard(int i)
        {
            try
            {
                this.serialPort.PortName = "COM" + i++;
                this.serialPort.Open();  
            }
            catch (System.IO.IOException ex)
            {
                OpenBoard(i);
            }
        }        

        private BarTenderController(string portName, int baudRate)
        {
            this.serialPort = new SerialPort();
            this.serialPort.PortName = portName;
            this.serialPort.BaudRate = baudRate;
            this.serialPort.Open(); 
        }

        public static BarTenderController Controller
        {
            get
            {
                lock (padlock)
                {
                    if (controller == null)                    
                        controller = new BarTenderController();                    
                    return controller;
                }
            }
        }

        public SerialPort SerialPort
        {
            get { return this.serialPort; }
        }

        //Checks if Arduino Port is open
        public bool IsArduinoPortOpened()
        {
            return this.serialPort.IsOpen;
        }

        public void CloseSerialPort()
        {
            this.serialPort.Close();
        }

        public void OpenSerialPort()
        {
            this.serialPort.Open();
        }        

        private void WriteToSerial(string msg)
        {
            this.serialPort.Write(msg + "\n");            
        }

        public string ReadFromSerial()
        {
            string temp = this.serialPort.ReadExisting();
            //loop in case there is a delay from arduino
            while (temp == string.Empty)
            {
                System.Threading.Thread.Sleep(10);
                temp = this.serialPort.ReadExisting();
            }            
            return temp;
        }
        
        public string PumpOn(int pumpNum)
        {
            return PumpOn(pumpNum, ProtocolDef.PUMP_ON_INTERVAL);
        }

        public string PumpOn(int pumpNum, int interval)
        {            
            if (IsArduinoPortOpened())
            {
                QueryString query = new QueryString(Device.PUMP, ProtocolDef.SET_MOTOR);
                query.SubQueries.Add(pumpNum.ToString());
                query.SubQueries.Add(ProtocolDef.ON);
                query.SubQueries.Add(interval.ToString());

                WriteToSerial(query.ToString());

                try
                {
                    //debugging
                    string temp1 = ReadFromSerial();
                    int success = int.Parse(temp1);
                    if (success == 0)
                        return ProtocolDef.SUCCESS;

                    return ProtocolDef.SERIALPORT_READ_ERROR;
                }
                catch //(Exception ex)
                {
                    return ProtocolDef.SERIALPORT_READ_ERROR;
                }               
            }
            return ProtocolDef.SERIALPORT_NOT_OPENED_ERROR;
        }

        public string PumpOff(int pumpNum)
        {
            if (IsArduinoPortOpened())
            {
                QueryString query = new QueryString(Device.PUMP, ProtocolDef.SET_MOTOR);
                query.SubQueries.Add(pumpNum.ToString());
                query.SubQueries.Add(ProtocolDef.OFF);
                query.SubQueries.Add("0");

                WriteToSerial(query.ToString());

                try
                {
                    if (int.Parse(ReadFromSerial()) == 0)
                        return ProtocolDef.SUCCESS;                        
                }
                catch //(Exception ex)
                {
                    return ProtocolDef.SERIALPORT_READ_ERROR;;
                }                
            }
            return ProtocolDef.SERIALPORT_NOT_OPENED_ERROR;
        }

        //Get Breathanalyzer value from Arduino
        public string GetBreathResult()
        {
            if (IsArduinoPortOpened())
            {
                QueryString query = new QueryString(Device.BREATH, ProtocolDef.GET_BREATH);
                WriteToSerial(query.ToString());
               
                return ReadFromSerial();    // 0 pass 1 fail -1 try again
            }
            return ProtocolDef.SERIALPORT_NOT_OPENED_ERROR;
        }        

        //Get Force Sensor Reading from Arduino
        public string GetForceSensorResult()
        {
            if (IsArduinoPortOpened())
            {
                QueryString query = new QueryString(Device.FORCESENSOR, ProtocolDef.GET_FORCESENSOR);
                WriteToSerial(query.ToString());
               
                return ReadFromSerial();               
            }
            return "1";
        }

        //Get Magnetic Strip Reading from Arduino
        public int GetCardReading()
        {
            if (IsArduinoPortOpened())
            {
                QueryString query = new QueryString(Device.CARDREADER, ProtocolDef.GET_CARDREADER);
                WriteToSerial(query.ToString());

                try
                {
                    return int.Parse(ReadFromSerial());
                }
                catch //(Exception ex)
                {

                }
            }
            return 1;
        }

        //TestLED from Arduino
        public int TestLED(int delay, int forcereturn)
        {
            if (IsArduinoPortOpened())
            {
                QueryString query = new QueryString(Device.TEST_DEVICE, ProtocolDef.TEST_LED);
                query.SubQueries.Add(delay.ToString());
                query.SubQueries.Add(forcereturn.ToString());                

                try
                {
                    return int.Parse(ReadFromSerial());
                }
                catch //(Exception ex)
                {

                }
            }
            return 1;
        }
    }
}
