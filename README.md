# ModbusTCP Client example by using sockets in C#
 
Very simple ModbusTCP Sample example in C# that uses network .NET sockets library (System.Net.Sockets) to read holding registers from a ModbusTCP Server device.
No Modbus libraries like EasymodbusTCP are used. 
First the connection through a socket is established, then the Modbus request message is sent and lastly the socket is waiting for response from ModbusTCP Server
ModRSsim2 can be used to simulate the Modbus TCP Server.
