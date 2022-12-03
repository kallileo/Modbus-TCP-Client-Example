# ModbusTCP Client example by using sockets in C#
 
Very simple ModbusTCP Client example coded in C# that uses network .NET sockets library (System.Net.Sockets) to read holding registers from a ModbusTCP Server device.
No EXTERNAL Modbus libraries like EasymodbusTCP are used. 

Firstly the connection through a network socket is established, then a Modbus request message is sent and lastly the socket is waiting for response from ModbusTCP Server.
ModRSsim2 can be used to simulate the ModbusTCP Server device.
