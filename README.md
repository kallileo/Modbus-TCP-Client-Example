# Modbus TCP Client example by using sockets in C#
 
Very simple Modbus TCP Client example coded in C# that uses network .NET sockets library (System.Net.Sockets) to read holding registers from a Modbus TCP Server device.
No EXTERNAL Modbus libraries like EasymodbusTCP are used. 

Firstly the connection through a network socket is established, then a Modbus request message is constructed and sent to the Modbus TCP Server. Lastly the socket is waiting for response from Modbus TCP Server.
ModRSsim2 can be used to simulate the Modbus TCP Server device.
