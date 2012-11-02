#ifndef PROTOCOL_HEADER
#define PROTOCOL_HEADER

struct TX_PROTO
{
  char *s_output;          // assuming output from arudrino to UI is a string (struct defined by c# UI)
  int i_output;            // if output is int then use this
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

#endif
