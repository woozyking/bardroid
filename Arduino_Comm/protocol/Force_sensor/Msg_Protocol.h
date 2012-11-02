struct TX_PROTO
{
  // "device=ret_value"
  char *output_str;          // assuming output from arudrino to UI is a string (struct defined by c# UI)
};

struct RX_PROTO
{
  int RW;                    // can be a read or write operation
  char* parameters;          // initial input data for function(s) to be executed ex. pump ON or pump OFF
  char* func_name;           // can set function name but need a way to resolve address
};

struct MSG_PROTOCOL
{
  int   device;              // Device to be controlled (pump,breath,forcesensor)      
  int   msg_size;            // Size of message (may not need but may be useful for syn/ack)
  struct RX_PROTO rx_data;   // if its serial read use this
  struct TX_PROTO tx_data;   // if its serial write use this
};

